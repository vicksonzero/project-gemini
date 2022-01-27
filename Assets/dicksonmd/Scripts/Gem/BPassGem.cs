using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BPassGem : MonoBehaviour
{
    public BGem gem;

    public BPlayer player1;
    public BPlayer player2;
    private PlayerInput playerInput;



    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInput.actions["PassGem"].triggered)
        {
            PassGem();
        }
    }

    public void PassGem()
    {
        gem.PassToPlayer(gem.player == player2 ? player1 : player2);
    }
}
