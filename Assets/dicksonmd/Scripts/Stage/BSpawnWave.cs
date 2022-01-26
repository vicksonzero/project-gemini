using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BSpawnWave : MonoBehaviour
{
    public bool mirrored = false;
    public BSpawnTick[] spawnTicks;

    public int nextTickId = 0;
    public float nextTickTime = -1;
    public float fixedTime = -1;

    public float GetWaveLength()
    {
        return spawnTicks.Select(t => t.waitTime)
            .Aggregate(0f, (acc, v) => acc + v);
    }

    void OnValidate()
    {
        spawnTicks = GetComponents<BSpawnTick>();

        for (int i = 0; i < spawnTicks.Length; i++)
        {
            spawnTicks[i].tickId = i;
        }

        if (mirrored)
        {
            foreach (var tickObj in spawnTicks)
            {
                tickObj.ApplyMirror();
            }
            mirrored = false;
        }
    }

    void Awake()
    {
        Debug.Log($"{nameof(BSpawnWave)} {name} Awake()");
        spawnTicks = GetComponents<BSpawnTick>();
        foreach (var tickObj in spawnTicks)
        {
            foreach (var obj in tickObj.objects)
            {
                obj.SetActive(false);
            }
        }
    }

    void Start()
    {
        Debug.Log($"BSpawnWave Start (Length={GetWaveLength()}");
    }

    void FixedUpdate()
    {
        fixedTime = Time.fixedTime;

        while (nextTickId < spawnTicks.Length && Time.fixedTime >= nextTickTime)
        {
            var tick = spawnTicks[nextTickId];
            tick.ActivateObjects();
            nextTickTime = Time.fixedTime + tick.waitTime;
            tick.doneTick = true;
            nextTickId++;

            if (nextTickId >= spawnTicks.Length)
            {
                Debug.Log("BSpawnWave Done");
            }
        }
    }
}
