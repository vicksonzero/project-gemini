using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemySpreadShootGun : MonoBehaviour
{
    public Transform bullPrefab;
    public float bullSpeed = 2;

    public void Shoot()
    {
        var bull = Instantiate(bullPrefab, transform.position, Quaternion.identity);
        bull.transform.position += Vector3.forward;
        var bullRb = bull.GetComponent<Rigidbody2D>();
        var dir = transform.up;
        bullRb.velocity = dir * bullSpeed;
    }
}
