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
            // Debug.Log("transfer");
            gem.PassToPlayer(gem.player == player2 ? player1 : player2);
        }
        // var fromTransform = whoWillHaveGem switch
        // {
        //     PlayerEnum.PLAYER_1 => player2Anchor,
        //     PlayerEnum.PLAYER_2 => player1Anchor,
        //     PlayerEnum.NO_ONE => transform,
        //     _ => throw new System.Exception("Unknown PlayerEnum"),
        // };
        // var toTransform = whoWillHaveGem switch
        // {
        //     PlayerEnum.PLAYER_1 => player1Anchor,
        //     PlayerEnum.PLAYER_2 => player2Anchor,
        //     PlayerEnum.NO_ONE => transform,
        //     _ => throw new System.Exception("Unknown PlayerEnum"),
        // };


        // gem.transform.position = Vector3.Lerp(fromTransform.position, toTransform.position, 0);
    }
}
