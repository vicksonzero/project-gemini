using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAutoDie : MonoBehaviour
{
    public float lifeTime = 0;
    public float nextCanDie = 0;

    void Start()
    {
        nextCanDie = Time.fixedTime + lifeTime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime >= nextCanDie)
        {
            Destroy(gameObject);
        }
    }
}
