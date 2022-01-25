using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemyBullet : MonoBehaviour
{
    public GameObject onHitEffect;
    public GameObject onEraseEffect;
    public bool isPierce = false;
    public static int nextId = 0;

    public int bulletId = 0;
    public void OnHitEraser(Collider2D collider)
    {
        Instantiate(onEraseEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
