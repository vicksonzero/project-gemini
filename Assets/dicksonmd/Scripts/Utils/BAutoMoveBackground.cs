using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAutoMoveBackground : MonoBehaviour
{
    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }
}
