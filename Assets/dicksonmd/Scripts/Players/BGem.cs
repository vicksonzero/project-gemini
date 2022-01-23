using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGem : MonoBehaviour
{
    public BPlayer player;
    public float moveSpeed = 3;

    public void PassToPlayer(BPlayer player)
    {
        var oldPlayer = this.player;
        this.player = player;
        moveSpeed = (player.gemAnchor.position - transform.position).magnitude * 1.5f;

        oldPlayer?.OnGemRemoved();
        player?.OnGemAdded();
    }

    public void Update()
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
