using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemyStopShootLeaveBehaviour : MonoBehaviour
{
    [Tooltip("in seconds")]
    public float rapid = 0.3f;
    public float nextCanShoot = 0;

    public BEnemySpreadShootGun[] guns;

    public int gunID = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextCanShoot = Time.fixedTime;
        guns = GetComponentsInChildren<BEnemySpreadShootGun>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime >= nextCanShoot)
        {
            ShootAllGuns();
            gunID = (gunID + 1) % guns.Length;
            nextCanShoot = Time.fixedTime + rapid;
        }
    }
    void ShootAllGuns()
    {
        foreach (var gun in guns)
        {
            gun.Shoot();
        }
    }
}
