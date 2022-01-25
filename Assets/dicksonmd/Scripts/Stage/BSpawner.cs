using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BEnemyEntryStayLeaveBehaviour;
using static BEnemyRunStraightBehaviour;

public class BSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject basicEnemyPrefab;
    public GameObject flockEnemyPrefab;
    [Header("Scripting")]

    public Vector3 spawnPos;
    public Vector3 stopPos;

    [Header("States")]
    public float fixedTime;
    public float nextTick;
    public int nextIndex;

    protected SpawnEnemyMethod[] spawnScript;
    public delegate void SpawnEnemyMethod();

    protected EnemyEntryStayLeaveParams enemyEntryStayLeaveParams;
    protected EnemyRunStraightParams enemyRunStraightParams;



    // Start is called before the first frame update
    void Start()
    {
        spawnPos = Vector3.zero;
        stopPos = Vector3.down;

        enemyEntryStayLeaveParams = new EnemyEntryStayLeaveParams()
        {
            moveSpeed = 2,
            moveDir = new Vector3(-1, 0.5f, 0),
            steer = 0.35f,
            stopPos = stopPos,

            stayTime = 3,
            rapid = 1.3f,

            shootDuringEntry = false,
            shootDuringStay = true,
            shootDuringLeave = false,
        };

        enemyRunStraightParams = new EnemyRunStraightParams()
        {
            moveSpeed = 2,
            moveDir = new Vector3(-1, 0.5f, 0),
            steer = 0.35f,
            stopPos = stopPos,

            shootDuringEntry = false,
            shootDuringLeave = false,
        };

        // TODO: change into list of commands so that i can isolate Wait() commands
        spawnScript = new SpawnEnemyMethod[] {
            () => Wait(2),
            () => Debug.Log("Start"),
            () => Debug.Log("Wave 1R"),

            () => {
                spawnPos = new Vector3(7, -4);
                stopPos = new Vector3(-7, -7);

                enemyRunStraightParams.moveDir = new Vector3(-1, 0.7f);
                enemyRunStraightParams.stopPos = stopPos;
                enemyRunStraightParams.shootDuringEntry = false;
                enemyRunStraightParams.shootDuringLeave = false;
            },
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(5),
            () => Debug.Log("Wave 1L"),

            () => {
                spawnPos = new Vector3(-7, -4);
                stopPos = new Vector3(7, -7);

                enemyRunStraightParams.moveDir = new Vector3(1, 0.7f);
                enemyRunStraightParams.stopPos = stopPos;
                enemyRunStraightParams.shootDuringEntry = false;
                enemyRunStraightParams.shootDuringLeave = false;
            },
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(0.8f),
            () => Spawn2(flockEnemyPrefab, enemyRunStraightParams),
            () => Wait(5),

            () => Debug.Log("Wave 2R"),

            () => {
                spawnPos = Vector3.right;
                stopPos = spawnPos + Vector3.down * 4f;

                enemyEntryStayLeaveParams.moveDir = Vector3.down;
                enemyEntryStayLeaveParams.stopPos = stopPos;
                enemyEntryStayLeaveParams.stayTime = 3;
                enemyEntryStayLeaveParams.rapid = 1.3f;
                enemyEntryStayLeaveParams.shootDuringEntry = false;
                enemyEntryStayLeaveParams.shootDuringStay = true;
                enemyEntryStayLeaveParams.shootDuringLeave = false;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Wait(1),
            () => {
                spawnPos.x += 1.5f;
                stopPos.x = spawnPos.x;
                stopPos.y -= 0.5f;
                enemyEntryStayLeaveParams.stopPos = stopPos;
            },
            // () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            // () => Wait(1),
            () => {
                spawnPos.x += 1.5f;
                stopPos.x = spawnPos.x;
                stopPos.y -= 0.5f;
                enemyEntryStayLeaveParams.stopPos = stopPos;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Wait(6),



            () => Debug.Log("Wave 2L"),
            () => {
                spawnPos = Vector3.left;
                stopPos = spawnPos + Vector3.down * 4f;

                enemyEntryStayLeaveParams.moveDir = Vector3.down;
                enemyEntryStayLeaveParams.stopPos = stopPos;
                enemyEntryStayLeaveParams.stayTime = 3;
                enemyEntryStayLeaveParams.rapid = 1.3f;
                enemyEntryStayLeaveParams.shootDuringEntry = false;
                enemyEntryStayLeaveParams.shootDuringStay = true;
                enemyEntryStayLeaveParams.shootDuringLeave = false;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Wait(1),
            () => {
                spawnPos.x -= 1.5f;
                stopPos.x = spawnPos.x;
                stopPos.y -= 0.5f;
                enemyEntryStayLeaveParams.stopPos = stopPos;
            },
            // () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            // () => Wait(1),
            () => {
                spawnPos.x -= 1.5f;
                stopPos.x = spawnPos.x;
                stopPos.y -= 0.5f;
                enemyEntryStayLeaveParams.stopPos = stopPos;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Wait(6),


            () => Debug.Log("Wave 3L"),
            () => {
                spawnPos = Vector3.left;
                stopPos = spawnPos + Vector3.down * 4f;

                enemyEntryStayLeaveParams.moveDir = Vector3.down;
                enemyEntryStayLeaveParams.stopPos = stopPos;
                enemyEntryStayLeaveParams.stayTime = 3;
                enemyEntryStayLeaveParams.rapid = 1.3f;
                enemyEntryStayLeaveParams.shootDuringEntry = false;
                enemyEntryStayLeaveParams.shootDuringStay = true;
                enemyEntryStayLeaveParams.shootDuringLeave = false;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Wait(1),
            () => {
                spawnPos.x -= 1.5f;
                stopPos.x = spawnPos.x;
                stopPos.y -= 0.5f;
                enemyEntryStayLeaveParams.stopPos = stopPos;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Wait(1),
            () => {
                spawnPos.x -= 1.5f;
                stopPos.x = spawnPos.x;
                stopPos.y -= 0.5f;
                enemyEntryStayLeaveParams.stopPos = stopPos;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Wait(6),


            () => Debug.Log("Wave 3R"),
            () => {
                spawnPos = Vector3.right;
                stopPos = spawnPos + Vector3.down * 4f;

                enemyEntryStayLeaveParams.moveDir = Vector3.down;
                enemyEntryStayLeaveParams.stopPos = stopPos;
                enemyEntryStayLeaveParams.stayTime = 3;
                enemyEntryStayLeaveParams.rapid = 1.3f;
                enemyEntryStayLeaveParams.shootDuringEntry = false;
                enemyEntryStayLeaveParams.shootDuringStay = true;
                enemyEntryStayLeaveParams.shootDuringLeave = false;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Wait(1),
            () => {
                spawnPos.x += 1.5f;
                stopPos.x = spawnPos.x;
                stopPos.y -= 0.5f;
                enemyEntryStayLeaveParams.stopPos = stopPos;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Wait(1),
            () => {
                spawnPos.x += 1.5f;
                stopPos.x = spawnPos.x;
                stopPos.y -= 0.5f;
                enemyEntryStayLeaveParams.stopPos = stopPos;
            },
            () => Spawn1(basicEnemyPrefab, enemyEntryStayLeaveParams),
            () => Loop(7),

            // never
            () => Debug.Log("End"),

        };
    }

    void Spawn1(GameObject prefab, EnemyEntryStayLeaveParams enemyEntryStayLeaveParams)
    {
        var enemy = Instantiate(prefab);
        enemy.transform.position = spawnPos;
        var entryStayLeave = enemy.AddComponent<BEnemyEntryStayLeaveBehaviour>();
        entryStayLeave.InitParams(enemyEntryStayLeaveParams);
    }

    void Spawn2(GameObject prefab, EnemyRunStraightParams enemyRunStraightParams)
    {
        var enemy = Instantiate(prefab);
        enemy.transform.position = spawnPos;
        var entryStayLeave = enemy.AddComponent<BEnemyRunStraightBehaviour>();
        entryStayLeave.InitParams(enemyRunStraightParams);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fixedTime += Time.fixedDeltaTime;

        while (nextIndex < spawnScript.Length && fixedTime >= nextTick)
        {
            spawnScript[nextIndex].Invoke();
            nextIndex++;
        }
    }

    void Loop(float fixedSeconds)
    {
        nextIndex = 0;
        nextTick += fixedSeconds;
    }

    void Wait(float fixedSeconds)
    {
        nextTick += fixedSeconds;
    }
}
