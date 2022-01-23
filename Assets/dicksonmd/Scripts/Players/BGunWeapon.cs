using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGunWeapon : MonoBehaviour
{
    [Header("Data")]
    public BBullet bulletPrefab;
    [Tooltip("in seconds")]
    public float rapid = 0.3f;
    [Tooltip("in degrees")]
    public float spray = 0;
    public float bulletSpeed = 1;

    public BGunWeapon prevLevelWeapon = null;
    public BGunWeapon nextLevelWeapon = null;

    [Header("States")]
    public float nextCanShoot = 0;

    BPlayer player;

    public Transform[] guns;

    public int gunID = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextCanShoot = Time.fixedTime;
        player = GetComponentInParent<BPlayer>();

        if (player == null) enabled = false;
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

    public void TryUpgrade()
    {
        if (nextLevelWeapon != null)
        {
            var newWeapon = Instantiate(nextLevelWeapon, player.transform);
            newWeapon.gameObject.SetActive(gameObject.activeSelf);
            Destroy(gameObject);
        }
    }

    public void TryDowngrade()
    {
        if (prevLevelWeapon != null)
        {
            var newWeapon = Instantiate(prevLevelWeapon, player.transform);
            newWeapon.gameObject.SetActive(gameObject.activeSelf);
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        var gun = guns[gunID];
        var bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        bullet.transform.position += Vector3.forward;
        var bulletRb = bullet.GetComponent<Rigidbody2D>();
        var degrees = Random.Range(-spray, spray);
        var dir = Quaternion.Euler(0, 0, degrees) * gun.transform.up;
        bulletRb.velocity = dir * bulletSpeed;
        bullet.transform.rotation = Quaternion.AngleAxis(degrees, Vector3.forward);
        if (gun.localPosition.x < 0)
        {
            bullet.transform.localScale = new Vector3(-1, 1, 1);
        }
        bullet.parentPlayer = player;
        if (bullet.GetComponent<BMeleeBullet>())
        {
            bullet.transform.SetParent(gun);
        }
    }
}
