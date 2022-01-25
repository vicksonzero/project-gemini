using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBulletEraser : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        var bullet = collider.GetComponentInParent<BEnemyBullet>();
        if (bullet == null) return;

        bullet.OnHitEraser(collider);
    }
}
