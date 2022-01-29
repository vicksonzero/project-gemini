using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static BEnemyEntryStayLeaveBehaviour;
using static BEnemyRunStraightBehaviour;

public class BSpawner : MonoBehaviour
{
    // [Header("Prefabs")]
    public BSpawnWave[] waves;
    public BFlyAwayToVictory flyAwayToVictory;

    [Header("States")]
    public int waveIndex;
    public float fixedTime;
    public float nextTick;
    public float totalTime;



    void OnValidate()
    {
        waves = GetComponentsInChildren<BSpawnWave>(true);

        totalTime = waves.Aggregate(0f, (acc, wave) => acc + wave.GetWaveLength());
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

        if (flyAwayToVictory == null) flyAwayToVictory = GetComponent<BFlyAwayToVictory>();
        flyAwayToVictory.enabled = false;
    }

    void Start()
    {
#if UNITY_EDITOR
        Debug.Log($"BSpawner UNITY_EDITOR: waveIndex={waveIndex}");
#else
        waveIndex = 0;
#endif
        nextTick += waves[waveIndex].GetWaveLength();
        waves[waveIndex].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fixedTime += Time.fixedDeltaTime;

        var waitingForBoss = waveIndex >= waves.Length ? false
            : (waves[waveIndex].isBoss && waves[waveIndex].GetComponentsInChildren<BEnemyAI>().Length > 0);
        if (waitingForBoss)
        {
            nextTick = fixedTime + waves[waveIndex].GetWaveLength();
        }
        while (waveIndex < waves.Length && fixedTime >= nextTick)
        {
            // // cannot deactivate, coz we have bg and still alive enemies
            // waves[nextIndex].gameObject.SetActive(false);
            waveIndex++;

            // waves[nextIndex].Invoke();
            if (waveIndex < waves.Length)
            {
                nextTick += waves[waveIndex].GetWaveLength();
                waves[waveIndex].gameObject.SetActive(true);
            }
            else
            {
                flyAwayToVictory.enabled = true;
            }
        }
    }

}
