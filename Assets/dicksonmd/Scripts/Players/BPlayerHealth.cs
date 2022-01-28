using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPlayerHealth : MonoBehaviour
{
    public float respawnLength = 10;
    public float respawnAt = 0;
    public bool isDead = false;
    public bool isStayDead = false;

    public SpriteRenderer playerSprite;
    public Text deathCountdownLabel;
    public ParticleSystem deathPS;

    BPassGem passGem;
    // Start is called before the first frame update
    void Start()
    {
        passGem = FindObjectOfType<BPassGem>();
        deathCountdownLabel.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead && deathCountdownLabel.enabled)
        {
            deathCountdownLabel.text = "" + (int)(respawnAt - Time.fixedTime + 1);
        }
        if (isDead && !isStayDead && Time.fixedTime >= respawnAt)
        {
            deathCountdownLabel.enabled = false;
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
        deathCountdownLabel.enabled = true;

        if (passGem.gem.player == GetComponent<BPlayer>())
        {
            passGem.PassGem();
        }

        var guns = GetComponentsInChildren<BGunWeapon>(true);
        foreach (var gun in guns)
        {
            gun.gameObject.SetActive(false);
        }
        var c = playerSprite.color;
        c.a = 0.5f;
        playerSprite.color = c;

        deathPS.Play();

        FindObjectOfType<BGameOver>().CheckGameOver();
    }

    public void Respawn()
    {
        isDead = false;
        isStayDead = false;

        var guns = GetComponentsInChildren<BGunWeapon>(true);
        foreach (var gun in guns)
        {
            gun.gameObject.SetActive(true);
        }
        var c = playerSprite.color;
        c.a = 1;
        playerSprite.color = c;
    }

    public void StayDead()
    {
        isStayDead = true;
        deathCountdownLabel.enabled = false;
    }
}
