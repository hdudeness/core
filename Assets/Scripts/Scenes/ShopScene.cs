using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ShopScene : MonoBehaviour {
    
    public GameManagement m;
    public Text ItemAmount0Health;
    public Text ItemAmount1ExtShield;
    public Text ItemAmount2TripShot;
    public Text ItemAmount3Wall;
    public Text ItemAmount4Supernova;
    public Text ItemAmount5Mine;
    public Text ItemAmount6Turret;
    public Text ItemAmount7OrbitBlades;
    public Text ItemCost0Health;
    public Text ItemCost1ExtShield;
    public Text ItemCost2TripShot;
    public Text ItemCost3Wall;
    public Text ItemCost4Supernova;
    public Text ItemCost5Mine;
    public Text ItemCost6Turret;
    public Text ItemCost7OrbitBlades;
    public int[,] itemInfo = new int[3, 8];

    public Sprite[] s1;
    public Sprite[] s2;
    public Sprite[] s3;
    public Sprite[] s4;
    public Image I1;
    public Image I2;
    public Image I3;
    public Image I4;
    public int[] skinCount = new int[4];


    public void skinUp(int slotNum) {
        skinCount[slotNum]++;
        if (skinCount[slotNum] == 8) skinCount[slotNum] = 0;
        if (slotNum == 0) I1.sprite = s1[skinCount[slotNum]];
        else if (slotNum == 1) I2.sprite = s2[skinCount[slotNum]];
        else if (slotNum == 2) I3.sprite = s3[skinCount[slotNum]];
        else if (slotNum == 3) I4.sprite = s4[skinCount[slotNum]];
    }

    public void skinDown(int slotNum) {
        skinCount[slotNum]--;
        if (skinCount[slotNum] == -1) skinCount[slotNum] = 7;
        if (slotNum == 0) I1.sprite = s1[skinCount[slotNum]];
        else if (slotNum == 1) I2.sprite = s2[skinCount[slotNum]];
        else if (slotNum == 2) I3.sprite = s3[skinCount[slotNum]];
        else if (slotNum == 3) I4.sprite = s4[skinCount[slotNum]];
    }

    public void incrementUp(int itemNumber) {
        itemInfo[0, itemNumber] ++;
        itemInfo[2, itemNumber] += itemInfo[1, itemNumber];
        updateText(itemNumber);
    }

    public void incrementDown(int itemNumber) {
        itemInfo[0, itemNumber] --;
        itemInfo[2, itemNumber] -= itemInfo[1, itemNumber];
        updateText(itemNumber);
    }

    public void purchaseItem(int itemNumber) {
        //m.items[itemNumber] += itemInfo[0, itemNumber];
        itemInfo[0, itemNumber] = 0;
        itemInfo[2, itemNumber] = 0;
        updateText(itemNumber);
    }

    public void updateText (int itemNumber) {
        if (itemNumber == 0) {
            ItemAmount0Health.text = itemInfo[0, 0].ToString();
            ItemCost0Health.text = itemInfo[2, 0].ToString();
        } else if (itemNumber == 1) {
            ItemAmount1ExtShield.text = itemInfo[0, 1].ToString();
            ItemCost1ExtShield.text = itemInfo[2, 1].ToString();
        } else if (itemNumber == 2) {
            ItemAmount2TripShot.text = itemInfo[0, 2].ToString();
            ItemCost2TripShot.text = itemInfo[2, 2].ToString();
        } else if (itemNumber == 3) {
            ItemAmount3Wall.text = itemInfo[0, 3].ToString();
            ItemCost3Wall.text = itemInfo[2, 3].ToString();
        } else if (itemNumber == 4) {
            ItemAmount4Supernova.text = itemInfo[0, 4].ToString();
            ItemCost4Supernova.text = itemInfo[2, 4].ToString();
        } else if (itemNumber == 5) {
            ItemAmount5Mine.text = itemInfo[0, 5].ToString();
            ItemCost5Mine.text = itemInfo[2, 5].ToString();
        } else if (itemNumber == 6) {
            ItemAmount6Turret.text = itemInfo[0, 6].ToString();
            ItemCost6Turret.text = itemInfo[2, 6].ToString();
        } else if (itemNumber == 7) {
            ItemAmount7OrbitBlades.text = itemInfo[0, 7].ToString();
            ItemCost7OrbitBlades.text = itemInfo[2, 7].ToString();
        }
    }

    public void mainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void descriptions() {
        SceneManager.LoadScene("Descriptions Screen");
    }

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 8; j++) {
                itemInfo[i, j] = 0;
            }
        }
        itemInfo[1, 0] = 20;
        itemInfo[1, 1] = 30;
        itemInfo[1, 2] = 40;
        itemInfo[1, 3] = 50;
        itemInfo[1, 4] = 60;
        itemInfo[1, 5] = 70;
        itemInfo[1, 6] = 80;
        itemInfo[1, 7] = 90;
        //enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
        //ItemAmount0Health = GameObject.Find("Item0Amount").GetComponent<TextObjects>();
    }

    // Update is called once per frame
    void Update() {
            //ItemAmount0Health.text = "45";
            //ItemCost0Health.text = itemInfo[2, 0].ToString();
    }
}
