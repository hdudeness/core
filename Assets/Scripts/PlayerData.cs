using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public string playerName;
    public int level;
    public int score;

    public PlayerData(GameManagement gameData)
    {
        playerName = gameData.playerName;
        level = gameData.level;
        score = gameData.score;
    }
    
}