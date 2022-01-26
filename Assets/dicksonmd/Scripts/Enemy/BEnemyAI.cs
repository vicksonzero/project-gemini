using System.Collections;
using System.Collections.Generic;
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

    public VEnemyAIAction[] actions;
    public int currentActionId = 0;

    public BEnemySpreadShootGun[] guns;

    public int gunID = 0;
    public float nextCanShoot = 0;
    void Awake()
    {
        actions = GetComponents<VEnemyAIAction>();
        foreach (var action in actions)
        {
            action.OnRegisterAction();
            action.enabled = false;
        }
    }

    void Start()
    {
        guns = GetComponentsInChildren<BEnemySpreadShootGun>();
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
        if (Time.fixedTime >= nextCanShoot)
        {
            ShootAllGuns();
            gunID = (gunID + 1) % guns.Length;
            nextCanShoot = Time.fixedTime + rapid;
        }
    }
    public void ShootAllGuns()
    {
        foreach (var gun in guns)
        {
            gun.Shoot();
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
        var _waypoint = transform.position;
        var _moveDir = moveDir;
        for (int i = 0; i < _actions.Length; i++)
        {
            var action = _actions[i];
#if UNITY_EDITOR
            Handles.Label(transform.position, action.GetType().ToString());
#endif
            action.DrawGizmo(ref _waypoint, ref _moveDir);
        }
    }


}
