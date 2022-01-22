using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void FixedUpdate()
    {
        Vector2 move = playerControls.Basic.Move1.ReadValue<Vector2>();

        // Debug.Log(move);
        float transfer = playerControls.Basic.Transfer.ReadValue<float>();

        // Debug.Log(transfer);
        if (playerControls.Basic.Transfer.triggered)
        {
            Debug.Log("transfer");
        }
    }
}
