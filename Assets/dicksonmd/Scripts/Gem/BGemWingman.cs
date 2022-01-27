using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGemWingman : MonoBehaviour
{
    public BGem gem;


    public float moveSpeed = 0.9f;
    public Transform target;


    void Awake()
    {
        if (gem == null) gem = FindObjectOfType<BGem>();
        foreach (var gun in GetComponentsInChildren<BGunWeapon>())
        {
            gun.player = gem.player;
            gun.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        var disp = target.position - transform.position;
        if (disp.magnitude < moveSpeed * Time.deltaTime)
        {
            transform.position = target.position;
        }
        else
        {
            transform.position += disp.normalized * moveSpeed * Time.fixedDeltaTime;
        }
    }

    public void PassToPlayer(BPlayer player)
    {
        foreach (var gun in GetComponentsInChildren<BGunWeapon>())
        {
            gun.player = gem.player;
        }
    }
}
