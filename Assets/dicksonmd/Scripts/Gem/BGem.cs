using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGem : MonoBehaviour
{
    public BPlayer player;
    public float moveSpeed = 3;
    public int bits = 0;

    public BGemWingman[] wingmans;

    public void Start()
    {
        if (player != null) player.OnGemAdded();
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

    public void AddBitValue(int value)
    {
        bits += value;

        foreach (var wingman in wingmans)
        {
            wingman.OnGemValueUpdated(bits);
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
