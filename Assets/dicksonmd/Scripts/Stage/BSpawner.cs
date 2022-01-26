using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BEnemyEntryStayLeaveBehaviour;
using static BEnemyRunStraightBehaviour;

public class BSpawner : MonoBehaviour
{
    // [Header("Prefabs")]
    public BSpawnWave[] waves;

    [Header("States")]
    public int nextIndex;
    public float fixedTime;
    public float nextTick;



    void OnValidate()
    {
        waves = GetComponentsInChildren<BSpawnWave>(true);
    }
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log($"{nameof(BSpawner)} {name} Awake()");
        waves = GetComponentsInChildren<BSpawnWave>(true);
        foreach (var waveObj in waves)
        {
            waveObj.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        nextIndex = 0;
        nextTick += waves[nextIndex].GetWaveLength();
        waves[nextIndex].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fixedTime = Time.fixedTime;
        while (nextIndex < waves.Length && fixedTime >= nextTick)
        {
            // // cannot deactivate, coz we have bg and still alive enemies
            // waves[nextIndex].gameObject.SetActive(false);
            nextIndex++;

            // waves[nextIndex].Invoke();
            nextTick += waves[nextIndex].GetWaveLength();
            waves[nextIndex].gameObject.SetActive(true);
        }
    }

}
