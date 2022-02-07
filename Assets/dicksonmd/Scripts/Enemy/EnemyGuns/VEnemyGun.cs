using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VEnemyGun : MonoBehaviour
{
    public abstract void Shoot(BEnemyAI ai, int burstLeft = 0);
}
