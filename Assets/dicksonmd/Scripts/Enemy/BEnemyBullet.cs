using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemyBullet : MonoBehaviour
{
    public GameObject onHitEffect;
    public GameObject onEraseEffect;
    public void OnHitEraser(Collider2D collider)
    {
        Instantiate(onEraseEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
