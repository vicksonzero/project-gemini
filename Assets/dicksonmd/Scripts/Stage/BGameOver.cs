using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BGameOver : MonoBehaviour
{
    public Canvas gameOverScreen;

    public Text retryCountLabel;
    public int retryCount = 0;
    public string retryText = "Retry: %COUNT%";
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.enabled = false;
        retryCountLabel.enabled = false;
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

    public void ContinueFromHere()
    {
        foreach (var player in FindObjectsOfType<BPlayerHealth>(true))
        {
            player.Revive();
        }
        FindObjectOfType<BSpawner>().enabled = true;

        gameOverScreen.enabled = false;

        if (retryCount <= 0) retryCountLabel.enabled = true;
        retryCount++;
        retryCountLabel.text = retryText.Replace("%COUNT%", "" + retryCount);
    }
}
