using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBullet : MonoBehaviour
{
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
}
