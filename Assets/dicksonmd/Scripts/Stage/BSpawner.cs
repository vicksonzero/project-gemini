using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BEnemyEntryStayLeaveBehaviour;

public class BSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject basicEnemyPrefab;
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

        // TODO: change into list of commands so that i can isolate Wait() commands
        spawnScript = new SpawnEnemyMethod[] {
            () => Wait(2),
            () => Debug.Log("Start"),
            () => Debug.Log("Wave 1R"),

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



            () => Debug.Log("Wave 1L"),
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
            () => Wait(8),


            () => Debug.Log("Wave 2"),
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
            () => Loop(5),

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