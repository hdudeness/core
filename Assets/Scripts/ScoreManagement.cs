using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManagement : MonoBehaviour
{
    public Text txtScore;
    public static int score = 0;

    public void scoreUpdate(int points)
    {
        score += points;
        txtScore.text = Convert.ToString(score);
    }


}
