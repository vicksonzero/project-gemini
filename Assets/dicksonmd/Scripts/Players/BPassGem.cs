using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPassGem : MonoBehaviour
{
    public BGem gem;

    public BPlayer player1;
    public BPlayer player2;
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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerControls.Basic.PassGem.triggered)
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
