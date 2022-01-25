using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEnemyHealth : MonoBehaviour
{
    public float hp = 10;
    public float maxHp = 10;

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

        if (hp <= 0)
        {
            Die(bullet.parentPlayer);
        }

        tookDamage.Add(bullet.bulletId);
    }

    public void Die(BPlayer killerPlayer)
    {
        // killerPlayer.StopCoroutine?
        Destroy(gameObject);
    }
}
