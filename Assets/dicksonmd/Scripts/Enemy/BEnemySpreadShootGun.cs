using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemySpreadShootGun : MonoBehaviour
{
    public Transform bulletPrefab;
    public float bulletSpeed = 2;
    public int bulletCount = 3;
    public bool bulletAimDown = true;
    [Tooltip("In degrees")]
    public float bulletSpread = 45;

    public void Shoot()
    {
        var dirStart = transform.up * (bulletAimDown ? -1 : 1);
        var angleStart = bulletSpread * (((float)bulletCount - 1) / 2);
        var dir = Quaternion.Euler(0, 0, -angleStart) * dirStart;

        for (int i = 0; i < bulletCount; i++)
        {
            ShootAtDirection(dir);
            dir = Quaternion.Euler(0, 0, bulletSpread) * dir;
        }
    }

    void ShootAtDirection(Vector3 dir)
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.position += Vector3.forward;
        var bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = dir * bulletSpeed;
    }
}
