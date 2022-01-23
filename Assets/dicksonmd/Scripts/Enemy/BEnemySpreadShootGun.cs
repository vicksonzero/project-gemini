using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemySpreadShootGun : MonoBehaviour
{
    public Transform bulletPrefab;
    public float bulletSpeed = 2;

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.position += Vector3.forward;
        var bulletRb = bullet.GetComponent<Rigidbody2D>();
        var dir = transform.up;
        bulletRb.velocity = dir * bulletSpeed;
    }
}
