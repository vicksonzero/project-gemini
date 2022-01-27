using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BGemCollector : MonoBehaviour
{
    public BGem gem;

    void Start()
    {
        if (gem == null) gem = FindObjectOfType<BGem>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        var bit = other.GetComponent<BGemBit>();
        if (bit == null) return;
        if (bit.target != null) return;

        bit.target = gem; ;
    }

    public void ChangeRadius(float val)
    {
        var collider = GetComponent<CircleCollider2D>();
        collider.radius = val;
    }
}
