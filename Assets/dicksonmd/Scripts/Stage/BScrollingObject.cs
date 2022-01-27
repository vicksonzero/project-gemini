using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BScrollingObject : MonoBehaviour
{
    public float vSpeed = 1;
    public bool useFixedUpdate = false;

    void Update()
    {
        if (useFixedUpdate) return;
        transform.Translate(Vector3.down * vSpeed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        if (!useFixedUpdate) return;
        transform.Translate(Vector3.down * vSpeed * Time.fixedDeltaTime);
    }
}
