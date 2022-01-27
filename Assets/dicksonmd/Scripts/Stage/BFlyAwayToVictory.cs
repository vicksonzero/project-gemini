using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFlyAwayToVictory : MonoBehaviour
{
    public float delay = 3;

    public float waitUntil = 0;
    public float force = 9;
    public float maxSpeed = 20;


    public BPlayer player1;
    public BPlayer player2;
    // Start is called before the first frame update
    void Start()
    {
        waitUntil = Time.fixedTime + delay;
        TurnOffPlayer(player1);
        TurnOffPlayer(player2);
        TurnOffWingmans();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime >= waitUntil)
        {
            PlayerTakeOff(player1);
            PlayerTakeOff(player2);
        }
    }

    void TurnOffWingmans()
    {
        foreach (var wingman in FindObjectsOfType<BGemWingman>())
        {
            foreach (var gun in wingman.GetComponentsInChildren<BGunWeapon>(true))
            {
                gun.enabled = false;
            }
        }
    }
    void TurnOffPlayer(BPlayer player)
    {
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<BPlayerHealth>().enabled = false;
        player.GetComponent<Collider2D>().enabled = false;
        foreach (var gun in player.GetComponentsInChildren<BGunWeapon>())
        {
            gun.enabled = false;
        }
    }
    void PlayerTakeOff(BPlayer player)
    {
        var rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
