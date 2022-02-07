using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BEnemyAI : MonoBehaviour
{
    [Header("Data")]
    public Vector3 moveDir;
    [Tooltip("in units per seconds")]
    public float moveSpeed = 2;
    [Tooltip("in fixed seconds")]
    public float rapid = 1.3f;

    [Header("States")]

    public Transform target;
    public bool isTargetGemPlayer = false;
    public bool showTargetLine = false;
    public VEnemyAIAction[] actions;
    public int currentActionId = 0;

    public VEnemyGun[] guns;

    public int gunID = 0;
    public float nextCanShoot = 0;
    public Vector3 startingPosition;
    public Vector3 startingMoveDir;
    BGem gem;

    void OnValidate()
    {
        actions = GetComponents<VEnemyAIAction>();
        Array.Sort(actions, (a, b) => (a.actionId - b.actionId));
    }
    void Awake()
    {
        gem = FindObjectOfType<BGem>();
        actions = GetComponents<VEnemyAIAction>();
        Array.Sort(actions, (a, b) => (a.actionId - b.actionId));
        foreach (var action in actions)
        {
            action.OnRegisterAction();
        }
        for (var i = actions.Length - 1; i >= 0; --i)
        {
            actions[i].enabled = false;
        }
        startingPosition = transform.position;
        startingMoveDir = moveDir;
    }

    void Start()
    {
        guns = GetComponentsInChildren<VEnemyGun>();
        nextCanShoot = Time.fixedTime;

        actions[0].enabled = true;
    }

    public void OnCurrentActionFinished()
    {
        Debug.Log($"BEnemyAI OnCurrentActionFinished");
        actions[currentActionId].enabled = false;
        currentActionId++;
        var noMoreActions = currentActionId >= actions.Length;
        if (noMoreActions)
        {
            Destroy(gameObject);
            return;
        }

        // enable action
        actions[currentActionId].enabled = true;
    }

    public void DoShoot()
    {
        if (guns.Length > 0 && Time.fixedTime >= nextCanShoot)
        {
            ShootAllGuns();
            gunID = (gunID + 1) % guns.Length;
            nextCanShoot = Time.fixedTime + rapid;
        }
    }
    public void ShootAllGuns()
    {
        if (isTargetGemPlayer) target = gem.player.transform;
        foreach (var gun in guns)
        {
            gun.Shoot(this, -1);
        }
    }


    public void SteerTowardsWaypoint(Vector3 waypoint, float maxSteer)
    {
        var targetDir = (waypoint - transform.position).normalized;
        var angle = Vector3.SignedAngle(moveDir, targetDir, Vector3.forward);

        if (Mathf.Abs(angle) < maxSteer)
        {
            moveDir = targetDir;
        }
        else
        {
            var rotateAmount = Mathf.Sign(angle) * maxSteer;
            moveDir = Quaternion.Euler(0, 0, rotateAmount) * moveDir;
        }
    }

    public bool MoveTowardsWaypoint(Vector3 waypoint)
    {
        var displacement = waypoint - transform.position;
        var arrived = false;
        if (displacement.magnitude < moveSpeed * Time.fixedDeltaTime)
        {
            transform.position = waypoint;
            arrived = true;
        }
        else
        {
            transform.position += moveDir * moveSpeed * Time.fixedDeltaTime;
        }

        return arrived;
    }


    public void OnDrawGizmos()
    {
        // debug
        var _actions = GetComponents<VEnemyAIAction>();
        Array.Sort(_actions, (a, b) => (a.actionId - b.actionId));
        var _waypoint = transform.position;
        var _moveDir = moveDir;

        if (Application.isPlaying)
        {
            _waypoint = startingPosition;
            _moveDir = startingMoveDir;
        }

        for (int i = 0; i < _actions.Length; i++)
        {
            var action = _actions[i];
#if UNITY_EDITOR
            Handles.Label(_waypoint, action.GetType().ToString());
#endif
            action.DrawGizmo(ref _waypoint, ref _moveDir);
        }
    }

    public void MirrorValues()
    {
        moveDir.x = -moveDir.x;

        var _actions = GetComponents<VEnemyAIAction>();
        Array.Sort(_actions, (a, b) => (a.actionId - b.actionId));
        foreach (var action in _actions)
        {
            action.MirrorValues();
        }
    }


}
