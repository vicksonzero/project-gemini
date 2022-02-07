using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemySpreadShootGun : VEnemyGun
{
    public Transform bulletPrefab;
    public float bulletSpeed = 2;
    public bool bulletAimDown = true;
    public bool bulletCanAimTarget = true;
    public Vector3 aimDir = Vector3.down;

    [Header("Spread")]
    public int bulletSpreadCount = 2;
    [Tooltip("In degrees")]
    public float bulletSpread = 45;

    [Header("Burst")]
    public int bulletBurstCount = 1;
    public float bulletBurstInterval = 0.2f;

    [Header("States")]
    public int bulletBurstLeft = 0;
    public float bulletBurstNextTick = 0;

    BEnemyAI ai;


    void FixedUpdate()
    {
        if (bulletBurstLeft > 0 && Time.fixedTime >= bulletBurstNextTick)
        {
            Shoot(ai, bulletBurstLeft);
            bulletBurstLeft--;
            bulletBurstNextTick = Time.fixedTime + bulletBurstInterval;
        }
    }

    public override void Shoot(BEnemyAI ai, int burstLeft = -1)
    {
        this.ai = ai;
        var aimDir = (bulletCanAimTarget && ai.target != null ? (ai.target.position - transform.position)
            : this.aimDir);
        aimDir.z = 0;
        var angleStart = bulletSpread * (((float)bulletSpreadCount - 1) / 2);
        var dir = Quaternion.Euler(0, 0, -angleStart) * aimDir.normalized;

        for (int i = 0; i < bulletSpreadCount; i++)
        {
            ShootAtDirection(dir);
            dir = Quaternion.Euler(0, 0, bulletSpread) * dir;
        }

        Debug.Log($"burstLeft: {burstLeft}");
        if (burstLeft == -1)
        {
            bulletBurstLeft = bulletBurstCount - 1;
            bulletBurstNextTick = Time.fixedTime + bulletBurstInterval;
        }
    }

    void ShootAtDirection(Vector3 dir)
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.position -= Vector3.forward * 2;
        var bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = dir * bulletSpeed;
    }
}
