using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BErasableBullet : MonoBehaviour
{
    public GameObject onEraseEffect;
    public void OnHitEraser(Collider2D collider)
    {
        Instantiate(onEraseEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
