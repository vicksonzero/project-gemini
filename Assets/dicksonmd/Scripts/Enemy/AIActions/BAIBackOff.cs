using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAIBackOff : VEnemyAIAction
{
    [Header("Data")]
    public bool doShoot = false;
    [Header("States")]
    public Vector3 waypoint;
    void OnEnable()
    {
        waypoint = transform.position;
        waypoint.y = -1;
        ai.moveDir = Vector3.up;
    }

    void FixedUpdate()
    {
        if (doShoot) ai.DoShoot();
        var arrived = ai.MoveTowardsWaypoint(waypoint);
        if (arrived)
        {
            ai.OnCurrentActionFinished();
        }
    }

    
    public override void DrawGizmo(ref Vector3 oldWaypoint, ref Vector3 oldMoveDir)
    {
        var _waypoint = oldWaypoint;
        _waypoint.y = -1;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(oldWaypoint, _waypoint);

        oldMoveDir = Vector3.up;
        oldWaypoint = _waypoint;
    }
}
