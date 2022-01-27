using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGem : MonoBehaviour
{
    public BPlayer player;
    public float moveSpeed = 3;
    public int bits = 0;

    public Image bitsGauge;
    public BGemWingman[] wingmans;

    public bool unlocked = false;

    public int[] upgradeReq;
    public int gunLv = 0;

    public void Start()
    {
        if (player != null) player.OnGemAdded();
        foreach (var wingman in wingmans)
        {
            wingman.gameObject.SetActive(false);
        }
        bitsGauge.fillAmount = 0;
    }

    public void PassToPlayer(BPlayer player)
    {
        if (player.GetComponent<BPlayerHealth>().isDead) return;

        var oldPlayer = this.player;
        this.player = player;
        moveSpeed = (player.gemAnchor.position - transform.position).magnitude * 1.5f;


        foreach (var wingman in wingmans)
        {
            wingman.PassToPlayer(player);
        }
        oldPlayer?.OnGemRemoved();
        player?.OnGemAdded();
    }

    public void AddBitValue(int newBits)
    {
        bits += newBits;

        if (!unlocked && bits >= upgradeReq[gunLv])
        {
            unlocked = true;
            gunLv++;

            foreach (var wingman in wingmans)
            {
                wingman.gameObject.SetActive(true);
                foreach (var gun in wingman.GetComponentsInChildren<BGunWeapon>(true))
                {
                    gun.gameObject.SetActive(true);
                }
            }
        }
        if (unlocked && gunLv < upgradeReq.Length && bits >= upgradeReq[gunLv])
        {
            foreach (var wingman in wingmans)
            {
                foreach (var gun in wingman.GetComponentsInChildren<BGunWeapon>(true))
                {
                    gun.TryUpgrade();
                }
            }
            foreach (var wingman in wingmans)
            {
                foreach (var gun in wingman.GetComponentsInChildren<BGunWeapon>(true))
                {
                    gun.player = player;
                    gun.enabled = true;
                }
            }
            gunLv++;
        }

        if (gunLv >= upgradeReq.Length)
        {
            bitsGauge.fillAmount = 0;
        }
        else
        {
            float lowerBound = gunLv <= 0 ? 0 : upgradeReq[gunLv - 1];
            float upperBound = upgradeReq[gunLv];
            float gaugePercent = ((float)bits - lowerBound) / (upperBound - lowerBound);
            Debug.Log($"{lowerBound}, {upperBound}, {gaugePercent}");
            bitsGauge.fillAmount = gaugePercent;
        }
    }

    public void FixedUpdate()
    {
        if (player != null)
        {
            moveSpeed += 30 * Time.deltaTime;
            var disp = player.gemAnchor.position - transform.position;
            if (disp.magnitude < moveSpeed * Time.deltaTime)
            {
                transform.position = player.gemAnchor.position;
            }
            else
            {
                transform.position += disp.normalized * moveSpeed * Time.fixedDeltaTime;
            }
        }
    }
}
