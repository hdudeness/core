using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string playerName;
    public int level;
    public int score;
    public Text txtScore;
    public Text txtLevel;
    public Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
        score = data.asset;
        nameText.text = playerName;
        txtScore.text = score.ToString();
        txtLevel.text = level.ToString();
    }
}
