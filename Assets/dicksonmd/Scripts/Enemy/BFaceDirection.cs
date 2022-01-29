using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFaceDirection : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
    }
}
