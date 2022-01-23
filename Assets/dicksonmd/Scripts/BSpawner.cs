using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject basicEnemyPrefab;
    [Header("Scripting")]

    public Vector3 spawnPointer;
    public Vector3 dirPointer;

    [Header("States")]
    public float fixedTime;
    public float nextTick;
    public int nextIndex;

    protected SpawnEnemyMethod[] spawnScript;
    public delegate void SpawnEnemyMethod();


    // Start is called before the first frame update
    void Start()
    {
        spawnPointer = Vector3.zero;
        dirPointer = Vector3.down;

        // TODO: change into list of commands so that i can isolate Wait() commands
        spawnScript = new SpawnEnemyMethod[] {
            () => Wait(2),
            () => Debug.Log("Start"),
            () => Debug.Log("Wave 1"),

            () => dirPointer = Vector3.down * 1.5f,
            () => {
                var enemy = Instantiate(basicEnemyPrefab);
                enemy.transform.position = transform.position + spawnPointer;
                var rb = enemy.GetComponent<Rigidbody2D>();
                rb.velocity = dirPointer;
                var ad = enemy.AddComponent<BAutoDie>();
                ad.lifeTime = 20;
            },
            () => spawnPointer.x += 1,
            () => Wait(1),
            () => {
                var enemy = Instantiate(basicEnemyPrefab);
                enemy.transform.position = transform.position + spawnPointer;
                var rb = enemy.GetComponent<Rigidbody2D>();
                rb.velocity = dirPointer;
                var ad = enemy.AddComponent<BAutoDie>();
                ad.lifeTime = 20;
            },
            () => spawnPointer.x += 1,
            () => Wait(1),
            () => {
                var enemy = Instantiate(basicEnemyPrefab);
                enemy.transform.position = transform.position + spawnPointer;
                var rb = enemy.GetComponent<Rigidbody2D>();
                rb.velocity = dirPointer;
                var ad = enemy.AddComponent<BAutoDie>();
                ad.lifeTime = 20;
            },
            () => spawnPointer.x += 1,
            () => Wait(1),
            () => {
                var enemy = Instantiate(basicEnemyPrefab);
                enemy.transform.position = transform.position + spawnPointer;
                var rb = enemy.GetComponent<Rigidbody2D>();
                rb.velocity = dirPointer;
                var ad = enemy.AddComponent<BAutoDie>();
                ad.lifeTime = 20;
            },
            () => spawnPointer.x += 1,
            () => Wait(4),



            () => Debug.Log("Wave 2"),
            () => spawnPointer = Vector3.zero,

            () => {
                var enemy = Instantiate(basicEnemyPrefab);
                enemy.transform.position = transform.position + spawnPointer;
                var rb = enemy.GetComponent<Rigidbody2D>();
                rb.velocity = dirPointer;
                var ad = enemy.AddComponent<BAutoDie>();
                ad.lifeTime = 20;
            },
            () => spawnPointer.x -= 1,
            () => Wait(1),
            () => {
                var enemy = Instantiate(basicEnemyPrefab);
                enemy.transform.position = transform.position + spawnPointer;
                var rb = enemy.GetComponent<Rigidbody2D>();
                rb.velocity = dirPointer;
                var ad = enemy.AddComponent<BAutoDie>();
                ad.lifeTime = 20;
            },
            () => spawnPointer.x -= 1,
            () => Wait(1),
            () => {
                var enemy = Instantiate(basicEnemyPrefab);
                enemy.transform.position = transform.position + spawnPointer;
                var rb = enemy.GetComponent<Rigidbody2D>();
                rb.velocity = dirPointer;
                var ad = enemy.AddComponent<BAutoDie>();
                ad.lifeTime = 20;
            },
            () => spawnPointer.x -= 1,
            () => Wait(1),
            () => {
                var enemy = Instantiate(basicEnemyPrefab);
                enemy.transform.position = transform.position + spawnPointer;
                var rb = enemy.GetComponent<Rigidbody2D>();
                rb.velocity = dirPointer;
                var ad = enemy.AddComponent<BAutoDie>();
                ad.lifeTime = 20;
            },
            () => spawnPointer.x -= 1,
            () => Debug.Log("End"),

        };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fixedTime += Time.fixedDeltaTime;

        while (nextIndex < spawnScript.Length && fixedTime >= nextTick)
        {
            spawnScript[nextIndex]();
            nextIndex++;
        }
    }

    void Wait(float fixedSeconds)
    {
        nextTick += fixedSeconds;
    }
}
