using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAIStay : VEnemyAIAction
{
    [Header("Data")]
    public float stayLength;
    public bool doShoot = true;
    [Header("States")]
    public float untilTime;
    void OnEnable()
    {
        Debug.Log($"BAIStay OnEnable");
        untilTime = Time.fixedTime + stayLength;
    }

    void FixedUpdate()
    {
        if (doShoot) ai.DoShoot();
        var timeIsUp = Time.fixedTime >= untilTime;
        Debug.Log($"BAIStay timeIsUp={timeIsUp}");
        if (timeIsUp)
        {
            ai.OnCurrentActionFinished();
        }
    }


    public override void DrawGizmo(ref Vector3 oldWaypoint, ref Vector3 oldMoveDir)
    {
        // nothing
    }
}
