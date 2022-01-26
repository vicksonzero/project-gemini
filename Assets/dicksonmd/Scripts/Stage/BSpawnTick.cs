using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BSpawnWave))]
public class BSpawnTick : MonoBehaviour
{
    public int tickId = -1;
    public GameObject[] objects;
    public float waitTime = 3;

    [Header("States")]
    public bool doneTick = false;

    public void ActivateObjects()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }
    void Awake()
    {
        if (waitTime <= 0)
        {
            Debug.LogError($"{name}.BSpawnTick: waitTime cannot be <=0");
        }
    }

    void OnValidate()
    {
        if (waitTime <= 0)
        {
            Debug.LogError($"{name}.BSpawnTick: waitTime cannot be <=0");
        }
    }
}
