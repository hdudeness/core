using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public string playerName;
    //public int level;
    public int score;
    public int money;
    public float timer;
    public int health;
    public string name1;
    public int highestScore1;
    public string name2;
    public int highestScore2;
    public string name3;
    public int highestScore3;
    public int[] items = new int[8];
    public int[] itemBar = new int[4];



    public PlayerData(GameManagement gameData)
    {
        playerName = gameData.playerName;
        //level = gameData.level;
        score = gameData.score;
        money = GameManagement.money;
        timer = gameData.timer;
        health = gameData.health.coreHealth;
        name1 = gameData.name1;
        highestScore1 = gameData.highestScore1;
        name2 = gameData.name2;
        highestScore2 = gameData.highestScore2;
        name3 = gameData.name3;
        highestScore3 = gameData.highestScore3;
        Array.Copy(GameManagement.items, 0, items, 0, 8);
        Array.Copy(GameManagement.itemBar, 0, itemBar, 0, 4);
    }
    
}