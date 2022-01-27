using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1 = true;
    public float moveSpeed = 0.1f;
    private PlayerInput playerInput;


    protected InputAction GetInputAction()
    {
        return isPlayer1 ? playerInput.actions["Player1Move"] : playerInput.actions["Player2Move"];
    }

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    void FixedUpdate()
    {
        Vector2 moveInput = GetInputAction().ReadValue<Vector2>();
        transform.Translate(moveInput * moveSpeed * Time.fixedDeltaTime);

        // Debug.Log(move);
    }
}
