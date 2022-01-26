using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BEnemyAI))]
public abstract class VEnemyAIAction : MonoBehaviour
{
    protected BEnemyAI ai;
    void Awake()
    {
        ai = GetComponent<BEnemyAI>();
    }

    public virtual void OnRegisterAction() { }

    public abstract void DrawGizmo(ref Vector3 oldWaypoint, ref Vector3 oldMoveDir);
}
