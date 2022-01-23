using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemyEntryStayLeaveBehaviour : MonoBehaviour
{
    public struct EnemyEntryStayLeaveParams
    {
        [Tooltip("in units per seconds")]
        public float moveSpeed;
        public Vector3 moveDir;
        [Tooltip("in degrees per seconds")]
        public float steer;
        public Vector3 stopPos;
        [Tooltip("in fixed seconds")]
        public float stayTime;
        [Tooltip("in fixed seconds")]
        public float rapid;
        public bool shootDuringEntry;
        public bool shootDuringStay;
        public bool shootDuringLeave;
    }
    public delegate void OnArriveAtStopPos();
    [Header("Data")]
    [Tooltip("in units per seconds")]
    public float moveSpeed;
    public Vector3 moveDir;
    [Tooltip("in degrees per seconds")]
    public float steer;
    public Vector3 stopPos;
    [Tooltip("in fixed seconds")]
    public float stayTime = 10f;
    [Tooltip("in fixed seconds")]
    public float rapid = 1.3f;
    public bool shootDuringEntry = false;
    public bool shootDuringStay = true;
    public bool shootDuringLeave = false;

    [Header("State")]
    public State state = State.ENTRY;
    public enum State { ENTRY, STAY, LEAVE };
    public float nextCanShoot = 0;
    public float nextCanLeave = 0;

    public BEnemySpreadShootGun[] guns;

    public int gunID = 0;

    public void InitParams(EnemyEntryStayLeaveParams obj)
    {
        this.moveSpeed = obj.moveSpeed;
        this.moveDir = obj.moveDir;
        this.steer = obj.steer;
        this.stopPos = obj.stopPos;
        this.stayTime = obj.stayTime;
        this.rapid = obj.rapid;
        this.shootDuringEntry = obj.shootDuringEntry;
        this.shootDuringStay = obj.shootDuringStay;
        this.shootDuringLeave = obj.shootDuringLeave;
    }

    // Start is called before the first frame update
    void Start()
    {
        guns = GetComponentsInChildren<BEnemySpreadShootGun>();
        nextCanShoot = Time.fixedTime;

        if (moveDir.magnitude == 0) moveDir = (stopPos - transform.position).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case State.ENTRY:
                if (shootDuringEntry) FixedDoShoot();
                FixedDoEntry();
                break;
            case State.STAY:
                if (shootDuringStay) FixedDoShoot();
                FixedDoStay();
                break;
            case State.LEAVE:
                if (shootDuringLeave) FixedDoShoot();
                FixedDoLeave();
                break;
        }
    }

    void FixedDoEntry()
    {
        SteerTowardsStopPos();
        MoveTowardsStopPos(() =>
        {
            // state change
            state = State.STAY;
            nextCanLeave = Time.fixedTime + stayTime;
        });
    }

    void FixedDoStay()
    {
        if (Time.fixedTime >= nextCanLeave)
        {
            // state change
            state = State.LEAVE;
            stopPos = transform.position;
            stopPos.y = 2;
            moveDir = Vector3.up;
        }
    }

    void FixedDoLeave()
    {
        SteerTowardsStopPos();
        MoveTowardsStopPos(() =>
        {
            Destroy(gameObject);
        });
    }

    void FixedDoShoot()
    {
        if (Time.fixedTime >= nextCanShoot)
        {
            ShootAllGuns();
            gunID = (gunID + 1) % guns.Length;
            nextCanShoot = Time.fixedTime + rapid;
        }
    }

    public void OnDrawGizmos()
    {
        // debug
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + moveDir);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, stopPos);
    }
    void ShootAllGuns()
    {
        foreach (var gun in guns)
        {
            gun.Shoot();
        }
    }

    void SteerTowardsStopPos()
    {
        var targetDir = (stopPos - transform.position).normalized;
        var angle = Vector3.SignedAngle(moveDir, targetDir, Vector3.forward);

        if (Mathf.Abs(angle) < steer)
        {
            moveDir = targetDir;
        }
        else
        {
            var rotateAmount = Mathf.Sign(angle) * steer;
            moveDir = Quaternion.Euler(0, 0, rotateAmount) * moveDir;
        }
    }

    void MoveTowardsStopPos(OnArriveAtStopPos onArriveAtStopPos)
    {
        var disp = stopPos - transform.position;
        if (disp.magnitude < moveSpeed * Time.fixedDeltaTime)
        {
            transform.position = stopPos;
            onArriveAtStopPos();
        }
        else
        {
            transform.position += moveDir * moveSpeed * Time.fixedDeltaTime;
        }
    }
}
