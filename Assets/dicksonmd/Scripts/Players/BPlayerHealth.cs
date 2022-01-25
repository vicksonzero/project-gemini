using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayerHealth : MonoBehaviour
{
    public float respawnLength = 10;
    public float respawnAt = 0;
    public bool isDead = false;

    public SpriteRenderer playerSprite;
    public ParticleSystem deathPS;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead && Time.fixedTime >= respawnAt)
        {
            Respawn();
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!enabled) return;
        var bullet = collider.GetComponentInParent<BEnemyBullet>();
        if (bullet == null) return;

        TakeDamage(bullet);
    }

    public void TakeDamage(BEnemyBullet bullet)
    {
        if (isDead) return;
        Die();
    }

    public void Die()
    {
        respawnAt = Time.fixedTime + respawnLength;
        isDead = true;
        var guns = GetComponentsInChildren<BGunWeapon>(true);
        foreach (var gun in guns)
        {
            gun.gameObject.SetActive(false);
        }
        var c = playerSprite.color;
        c.a = 0.5f;
        playerSprite.color = c;

        deathPS.Play();
    }

    public void Respawn()
    {
        isDead = false;
        var guns = GetComponentsInChildren<BGunWeapon>(true);
        foreach (var gun in guns)
        {
            gun.gameObject.SetActive(true);
        }
        var c = playerSprite.color;
        c.a = 1;
        playerSprite.color = c;
    }
}
