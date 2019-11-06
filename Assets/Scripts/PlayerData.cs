﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public string playerName;
    //public int level;
    public int score;
    public float timer;
    public int health;
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
    


    public PlayerData(GameManagement gameData)
    {
        playerName = gameData.playerName;
        //level = gameData.level;
        score = gameData.score;
        timer = gameData.timer;
        health = gameData.health.coreHealth;
        name1 = gameData.name1;
        highestScore1 = gameData.highestScore1;
        name2 = gameData.name2;
        highestScore2 = gameData.highestScore2;
        name3 = gameData.name3;
        highestScore3 = gameData.highestScore3;
        item1 = gameData.item1;
        item2 = gameData.item2;
        item3 = gameData.item3;
        item4 = gameData.item4;
    }
    
}