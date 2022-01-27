using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPlayerScore : MonoBehaviour
{
    public Text scoreLabel;
    public int score = 0;

    void Start()
    {
        UpdateLabel();
    }
    void UpdateLabel()
    {
        scoreLabel.text = String.Format("{0:n0}", score);
    }

    public void AddScore(int amount, bool doMultiplier)
    {
        score += (doMultiplier ? 1 : 1) * amount;
        UpdateLabel();
    }
}
