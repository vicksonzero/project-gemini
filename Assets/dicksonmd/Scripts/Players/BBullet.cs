using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBullet : MonoBehaviour
{
    public static int nextId = 0;
    public GameObject onHitEffect;
    public GameObject onEraseEffect;
    public bool isPierce = false;

    public int bulletId = 0;
    public BPlayer parentPlayer;
    public float dmg = 1;
    // Start is called before the first frame update
    void Start()
    {
        bulletId = ++nextId;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHitEnemy(Collider2D other)
    {
        
        // var colliders = GetComponentsInChildren<Collider2D>();
        // var collestPoints = colliders.Select(c => c.ClosestPoint(other.transform.position));
        // var minDist = collestPoints
        //     .Select(p => (other.transform.position - new Vector3(p.x, p.y, 0)).magnitude)
        //     .Aggregate(float.PositiveInfinity, (acc, d) => Mathf.Min(acc, d));
        // var collestPoint = collestPoints.First(p => (other.transform.position - new Vector3(p.x, p.y, 0)).magnitude == minDist);
        // Instantiate(onHitEffect, collestPoint, Quaternion.identity);
        Instantiate(onHitEffect, other.ClosestPoint(transform.position), Quaternion.identity);

        // create effect at collider.ClosestPoint
        if (isPierce)
        {
            // don't die
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
