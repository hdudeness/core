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
    public string name1;
    public int highestScore1;
    public string name2;
    public int highestScore2;
    public string name3;
    public int highestScore3;
    public bool item1;
    public bool item2;
    public bool item3;
    public bool item4;
    public Text txtScore;
    public Text txtLevel;
    public Text nameText;
    public Text timeDisplay;
    public float timer;
    public float minutes;
    public float seconds;
    private int secondsBetweenLevels = 20;
    //public static bool isLoaded = false;
    // Start is called before the first frame update

    void Start()
    {
        if (MainMenu.isLoaded)
        {
            this.Loader();
        }
        else
        {
            playerName = MainMenu.playerName;
        }
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
        if (txtScore != null)
        {
            txtScore.text = Convert.ToString(score);
        }
        
    }


    public void Saver()
    {
        playerDataUpdate();
        SaveSystem.Saver(this);
    }

    public void Loader()
    {
        PlayerData data = SaveSystem.Loader();
        playerName = data.playerName;
        //level = data.level;
        score = data.score;
        timer = data.timer;
        name1 = data.name1;
        highestScore1 = data.highestScore1;
        name2 = data.name2;
        highestScore2 = data.highestScore2;
        name3 = data.name3;
        highestScore3 = data.highestScore3;
        item1 = data.item1;
        item2 = data.item2;
        item3 = data.item3;
        item4 = data.item4;
        //nameText.text = playerName;
        txtScore.text = score.ToString();
    }

    private void playerDataUpdate()
    {
        if(score > highestScore1)
        {
            name3 = name2;
            highestScore3 = highestScore2;
            name2 = name1;
            highestScore2 = highestScore1;
            name1 = playerName;
            highestScore1 = score;
        }
        else if(score > highestScore2)
        {
            name3 = name2;
            highestScore3 = highestScore2;
            name2 = playerName;
            highestScore2 = score;
        }
        else if(score > highestScore3)
        {
            name3 = playerName;
            highestScore3 = score;
        }
    }
}
