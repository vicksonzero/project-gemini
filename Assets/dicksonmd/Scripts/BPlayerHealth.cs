using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        var bullet = collider.GetComponentInParent<BEnemyBullet>();
        if (bullet == null) return;

        TakeDamage(bullet);
    }

    public void TakeDamage(BEnemyBullet bullet)
    {

    }

}
