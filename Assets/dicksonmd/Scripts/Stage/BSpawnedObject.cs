using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSpawnedObject : MonoBehaviour
{
    // represents an object that will be spawned by a SpawnTick
    void Awake()
    {
        Debug.Log("BSpawnedObject Awake()");
    }
    void Start()
    {
        Debug.Log("BSpawnedObject Start()");
    }
}
