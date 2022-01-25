using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBulletEraser : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        var bullet = collider.GetComponentInParent<BErasableBullet>();
        if (bullet == null) return;

        bullet.OnHitEraser(GetComponent<Collider2D>());
    }
}
