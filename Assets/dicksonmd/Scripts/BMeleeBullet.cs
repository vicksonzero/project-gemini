using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BBullet))]
public class BMeleeBullet : MonoBehaviour
{
    public float meleeLifeTLme = 0;
    public float nextCanDie = 0;

    void Start()
    {
        nextCanDie = Time.fixedTime + meleeLifeTLme;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime >= nextCanDie)
        {
            foreach (var component in GetComponentsInChildren<Collider2D>())
            {
                component.enabled = false;
            }
        }
    }
}
