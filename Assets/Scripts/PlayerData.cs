using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public string playerName;
    public int level;
    public int asset;

    public PlayerData(Player player)
    {
        playerName = player.playerName;
        level = player.level;
        asset = player.score;
    }
    
}