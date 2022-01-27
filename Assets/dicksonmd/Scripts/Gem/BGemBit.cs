using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGemBit : MonoBehaviour
{
    public int value = 10;
    public BGem target;
    public float chaseSpeed = 5;
    public float scrollSpeed = 1;
    public float scatterSpeed = 1;

    void FixedUpdate()
    {
        if (target == null)
        {
            transform.Translate(Vector3.down * scrollSpeed * Time.fixedDeltaTime);
        }
        else
        {
            var arrived = MoveTowardsWaypoint(target.transform.position);
            if (arrived)
            {
                target.AddBitValue(value);
                Destroy(gameObject);
            }
        }
    }

    public void RandomlyScatter()
    {
        var rb = GetComponent<Rigidbody2D>();
        if (rb == null) return;

        rb.velocity = Random.insideUnitCircle * scatterSpeed;
    }
    public bool MoveTowardsWaypoint(Vector3 waypoint)
    {
        var displacement = waypoint - transform.position;
        var arrived = false;
        if (displacement.magnitude < chaseSpeed * Time.fixedDeltaTime)
        {
            transform.position = waypoint;
            arrived = true;
        }
        else
        {
            transform.position += displacement.normalized * chaseSpeed * Time.fixedDeltaTime;
        }

        return arrived;
    }
}
