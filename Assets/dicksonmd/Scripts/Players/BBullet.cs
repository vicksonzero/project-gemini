using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBullet : MonoBehaviour
{
    public GameObject onHitEffect;
    public GameObject onEraseEffect;
    public bool isPierce = false;
    public static int nextId = 0;

    public int id = 0;
    public BPlayer parentPlayer;
    public float dmg = 1;
    // Start is called before the first frame update
    void Start()
    {
        id = ++nextId;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHitEnemy(Collider2D collider)
    {
        Instantiate(onHitEffect, collider.ClosestPoint(transform.position), Quaternion.identity);

        // create effect at collider.ClosestPoint
        if (isPierce)
        {
            // don't die
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
