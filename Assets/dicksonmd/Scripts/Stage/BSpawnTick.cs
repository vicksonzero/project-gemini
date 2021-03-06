using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if (obj == null) continue;
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

    public void ApplyMirror()
    {
        foreach (var obj in objects)
        {
            if (obj == null) continue;
            var pos = obj.transform.position;
            pos.x = -pos.x;
            obj.transform.position = pos;
            obj.GetComponent<BEnemyAI>().MirrorValues();
        }
    }
}
