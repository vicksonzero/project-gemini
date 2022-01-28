using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BGameOver : MonoBehaviour
{
    public Canvas gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckGameOver()
    {
        var players = FindObjectsOfType<BPlayerHealth>(true);
        if (players.All(p => p.isDead))
        {
            Debug.Log("Game Over");
            foreach (var player in players)
            {
                player.StayDead();
            }
            FindObjectOfType<BSpawner>().enabled = false;

            gameOverScreen.enabled = true;
        }
    }
}
