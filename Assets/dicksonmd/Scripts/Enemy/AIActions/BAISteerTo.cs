using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAISteerTo : VEnemyAIAction
{
    public bool relative = true;
    public Vector3 waypoint;
    public float maxSteer = 0.35f;
    public bool doShoot = true;

    public override void OnRegisterAction()
    {
        if (relative) waypoint += transform.position;
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
        ai.SteerTowardsWaypoint(waypoint, maxSteer);
        var arrived = ai.MoveTowardsWaypoint(waypoint);
        if (arrived)
        {
            ai.OnCurrentActionFinished();
        }
        if (doShoot) ai.DoShoot();
    }

    public override void DrawGizmo(ref Vector3 oldWaypoint, ref Vector3 oldMoveDir)
    {
        var _waypoint = waypoint + (relative ? transform.position : Vector3.zero);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(oldWaypoint, oldWaypoint + oldMoveDir);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(oldWaypoint, _waypoint);

        oldMoveDir = waypoint - oldWaypoint;
        oldWaypoint = _waypoint;
    }
}
