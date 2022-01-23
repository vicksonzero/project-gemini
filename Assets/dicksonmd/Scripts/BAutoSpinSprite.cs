using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAutoSpinSprite : MonoBehaviour
{
    public float rotSpeed = 1;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
    }
}
