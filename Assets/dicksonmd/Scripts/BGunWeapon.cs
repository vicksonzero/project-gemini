using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGunWeapon : MonoBehaviour
{
    public BBullet bullPrefab;
    [Tooltip("in seconds")]
    public float rapid = 0.3f;
    [Tooltip("in degrees")]
    public float spray = 0;
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
        var gun = guns[gunID];
        var bull = Instantiate(bullPrefab, gun.position, Quaternion.identity);
        bull.transform.position += Vector3.forward;
        var bullRb = bull.GetComponent<Rigidbody2D>();
        var degrees = Random.Range(-spray, spray);
        var dir = Quaternion.Euler(0, 0, degrees) * gun.transform.up;
        bullRb.velocity = dir * bullSpeed;
        bull.transform.rotation = Quaternion.AngleAxis(degrees, Vector3.forward);
        if (gun.localPosition.x < 0)
        {
            bull.transform.localScale = new Vector3(-1, 1, 1);
        }

        if(bull.GetComponent<BMeleeBullet>()){
            bull.transform.SetParent(gun);
        }
    }
}
