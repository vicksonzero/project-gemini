using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1 = true;
    public float moveSpeed = 0.1f;
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

    protected InputAction GetInputAction()
    {
        return isPlayer1 ? playerControls.Basic.Player1Move : playerControls.Basic.Player2Move;
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
        Vector2 moveInput = GetInputAction().ReadValue<Vector2>();
        transform.Translate(moveInput *moveSpeed);

        // Debug.Log(move);
        float transfer = playerControls.Basic.Transfer.ReadValue<float>();

        // Debug.Log(transfer);
        if (playerControls.Basic.Transfer.triggered)
        {
            Debug.Log("transfer");
        }
    }
}
