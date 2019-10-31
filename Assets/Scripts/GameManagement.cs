using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public string playerName;
    public int level;
    public int score;
    public Text txtScore;
    public Text txtLevel;
    public Text nameText;
    public Text timeDisplay;
    public float timer;
    public float minutes;
    public float seconds;
    private int secondsBetweenLevels = 20;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        level = (int)(timer / secondsBetweenLevels) + 1;
        txtLevel.text = level.ToString();
        minutes = timer / 60;
        seconds = timer % 60;
        timeDisplay.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        
    }


    public void scoreUpdate(int points)
    {
        score += points;
        txtScore.text = Convert.ToString(score);
    }


    public void Saver()
    {
        playerName = nameText.text;
        score = int.Parse(txtScore.text);
        level = int.Parse(txtLevel.text);
        SaveSystem.Saver(this);
    }

    public void Loader()
    {
        PlayerData data = SaveSystem.Loader();
        playerName = data.playerName;
        level = data.level;
        score = data.score;
        //nameText.text = playerName;
        txtScore.text = score.ToString();
        //txtLevel.text = level.ToString();
    }
}
