using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text txtP1Name;
    public Text txtP1Score;
    public Text txtP2Name;
    public Text txtP2Score;
    public Text txtP3Name;
    public Text txtP3Score;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData gameData = SaveSystem.Loader();
        txtP1Name.text = gameData.name1;
        txtP1Score.text = gameData.highestScore1.ToString();
        txtP2Name.text = gameData.name2;
        txtP2Score.text = gameData.highestScore2.ToString();
        txtP3Name.text = gameData.name3;
        txtP3Score.text = gameData.highestScore3.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
