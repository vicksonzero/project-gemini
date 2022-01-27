using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGemWingman : MonoBehaviour
{
    public BGem gem;

    public bool unlocked = false;
    public int unlockThreshold = 500;

    public float moveSpeed = 0.9f;
    public Transform target;

    public int[] upgradeReq;
    public int gunLv = 0;

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
        if (!unlocked) return;
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

    public void OnGemValueUpdated(int value)
    {
        if (!unlocked && value >= unlockThreshold)
        {
            unlocked = true;
            foreach (var gun in GetComponentsInChildren<BGunWeapon>(true))
            {
                gun.gameObject.SetActive(true);
            }
        }
        if (unlocked && gunLv < upgradeReq.Length && value >= upgradeReq[gunLv])
        {
            foreach (var gun in GetComponentsInChildren<BGunWeapon>())
            {
                gun.TryUpgrade();
                gunLv++;
            }
            foreach (var gun in GetComponentsInChildren<BGunWeapon>())
            {
                gun.player = gem.player;
                gun.enabled = true;
            }
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
