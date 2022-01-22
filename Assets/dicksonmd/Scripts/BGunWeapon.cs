using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGunWeapon : MonoBehaviour
{
    public BBullet bullPrefab;
    [Tooltip("in seconds")]
    public float rapid = 0.3f;
    public float bullSpeed = 1;
    public float nextCanShoot = 0;

    public Transform[] guns;

    public int gunID = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextCanShoot = Time.fixedTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime >= nextCanShoot)
        {
            Shoot();
            gunID = (gunID + 1) % guns.Length;
            nextCanShoot = Time.fixedTime + rapid;
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot");
        var gun = guns[gunID];
        var bull = Instantiate(bullPrefab, gun.position, Quaternion.identity);
        var bullRb = bull.GetComponent<Rigidbody2D>();
        bullRb.velocity = gun.transform.up * bullSpeed;
    }
}
