using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BAITargeting : VEnemyAIAction
{
    public enum TargetMethod { NONE, NEAREST_PLAYER, GEM_PLAYER_NOW, GEM_PLAYER_TRACKING };
    [Header("Data")]
    public TargetMethod targetMethod;
    public bool showTargetLine;
    // [Header("States")]
    void OnEnable()
    {
        Debug.Log($"BAITarget OnEnable");

        ai.isTargetGemPlayer = false;
        ai.showTargetLine = showTargetLine;

        switch (targetMethod)
        {
            case TargetMethod.NONE:
                ai.target = null;
                break;
            case TargetMethod.NEAREST_PLAYER:
                ai.target = GetNearestPlayer().transform;
                break;
            case TargetMethod.GEM_PLAYER_NOW:
                var player = FindObjectOfType<BGem>().player;
                ai.target = (player == null ? GetNearestPlayer() : player).transform;
                break;
            case TargetMethod.GEM_PLAYER_TRACKING:
                ai.isTargetGemPlayer = true;
                break;
        }
    }

    void FixedUpdate()
    {
        ai.OnCurrentActionFinished();
    }

    BPlayer GetNearestPlayer()
    {
        var players = FindObjectsOfType<BPlayer>(true);
        var distances = players.Select((p, i) => new
        {
            Player = p,
            Value = (transform.position - p.transform.position).magnitude,
        });
        var nearestPlayer = distances.Aggregate((a, b) => (a.Value < b.Value) ? a : b).Player;
        return nearestPlayer;
    }

    public override void DrawGizmo(ref Vector3 oldWaypoint, ref Vector3 oldMoveDir)
    {
        // nothing
    }
}
