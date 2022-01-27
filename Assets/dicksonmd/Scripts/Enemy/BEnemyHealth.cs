using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemyHealth : MonoBehaviour
{
    public float hp = 10;
    public float maxHp = 10;

    public int hitScore = 100;
    public int deathScore = 1000;

    public GameObject deathEffect;

    public HashSet<int> tookDamage = new HashSet<int>();


    public void OnTriggerEnter2D(Collider2D collider)
    {
        var bullet = collider.GetComponentInParent<BBullet>();
        if (bullet == null) return;

        bullet.OnHitEnemy(GetComponent<Collider2D>());
        TakeDamage(bullet);
    }

    public void TakeDamage(BBullet bullet)
    {
        if (tookDamage.Contains(bullet.bulletId)) return;

        hp -= bullet.dmg;
        bullet.parentPlayer.GetComponent<BPlayerScore>().AddScore(hitScore, false);

        if (hp <= 0)
        {
            Die(bullet.parentPlayer);
        }

        tookDamage.Add(bullet.bulletId);
    }

    public void Die(BPlayer killerPlayer)
    {
        // killerPlayer.StopCoroutine?
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        killerPlayer.GetComponent<BPlayerScore>().AddScore(deathScore, true);

        GetComponent<BGemBitHolder>().ReleaseBits();

        Destroy(gameObject);
    }
}
