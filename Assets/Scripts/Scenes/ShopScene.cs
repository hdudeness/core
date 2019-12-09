using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ShopScene : MonoBehaviour {
    
    //public GameManagement m;
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
    
    public Text ItemOwned0Health;
    public Text ItemOwned1ExtShield;
    public Text ItemOwned2TripShot;
    public Text ItemOwned3Wall;
    public Text ItemOwned4Supernova;
    public Text ItemOwned5Mine;
    public Text ItemOwned6Turret;
    public Text ItemOwned7OrbitBlades;

    public Text moneyAvailable;

    public int[,] itemInfo = new int[3, 8];

    public Sprite[] s1;
    
    public Image I1;
    public Image I2;
    public Image I3;
    public Image I4;

    public bool isUpdated = false;
    
    public void skinUp(int slotNum) {
        bool skip;
        do {
            skip = false;
            GameManagement.itemBar[slotNum]++;
            if (GameManagement.itemBar[slotNum] == 8)  
                GameManagement.itemBar[slotNum] = 0; 
            for (int x = 0; x < 4; x++) {
                if (x != slotNum)
                    if (GameManagement.itemBar[slotNum] == GameManagement.itemBar[x])
                        skip = true;
            }
        } while (skip);

        if (slotNum == 0) 
            I1.sprite = s1[GameManagement.itemBar[slotNum]];
        else if (slotNum == 1) 
            I2.sprite = s1[GameManagement.itemBar[slotNum]];
        else if (slotNum == 2) 
            I3.sprite = s1[GameManagement.itemBar[slotNum]];
        else if (slotNum == 3) 
            I4.sprite = s1[GameManagement.itemBar[slotNum]];
    }

    public void skinDown(int slotNum) {
        bool skip;
        do {
            skip = false;
            GameManagement.itemBar[slotNum]--;
            if (GameManagement.itemBar[slotNum] == -1) GameManagement.itemBar[slotNum] = 7;
            for (int x = 0; x < 4; x++) {
                if (x != slotNum)
                    if (GameManagement.itemBar[slotNum] == GameManagement.itemBar[x])
                        skip = true;
            }
        } while (skip);
        if (slotNum == 0) I1.sprite = s1[GameManagement.itemBar[slotNum]];
        else if (slotNum == 1) I2.sprite = s1[GameManagement.itemBar[slotNum]];
        else if (slotNum == 2) I3.sprite = s1[GameManagement.itemBar[slotNum]];
        else if (slotNum == 3) I4.sprite = s1[GameManagement.itemBar[slotNum]];
    }

    public void updateSkin(int slotNum) {
        if (slotNum == 0) I1.sprite = s1[GameManagement.itemBar[slotNum]];
        else if (slotNum == 1) I2.sprite = s1[GameManagement.itemBar[slotNum]];
        else if (slotNum == 2) I3.sprite = s1[GameManagement.itemBar[slotNum]];
        else if (slotNum == 3) I4.sprite = s1[GameManagement.itemBar[slotNum]];
    }

    public void incrementUp(int itemNumber) {
        if (itemInfo[2, itemNumber] + itemInfo[1, itemNumber] <= GameManagement.money && (itemInfo[0, itemNumber] + GameManagement.items[itemNumber]) < 100) {
            itemInfo[0, itemNumber]++;
            itemInfo[2, itemNumber] += itemInfo[1, itemNumber];
            updateText(itemNumber);
        }
    }

    public void incrementDown(int itemNumber) {
        if (itemInfo[0, itemNumber] != 0) {
            itemInfo[0, itemNumber]--;
            itemInfo[2, itemNumber] -= itemInfo[1, itemNumber];
            updateText(itemNumber);
        }
    }

    public void purchaseItem(int itemNumber) {
        GameManagement.items[itemNumber] += itemInfo[0, itemNumber];
        itemInfo[0, itemNumber] = 0;
        GameManagement.money -= itemInfo[2, itemNumber];
        itemInfo[2, itemNumber] = 0;
        moneyAvailable.text = GameManagement.money.ToString();
        updateText(itemNumber);
    }

    public void updateText (int itemNumber) {
        if (itemNumber == 0) {
            ItemAmount0Health.text = itemInfo[0, 0].ToString();
            ItemCost0Health.text = itemInfo[2, 0].ToString();
            ItemOwned0Health.text = GameManagement.items[itemNumber].ToString();
        } else if (itemNumber == 1) {
            ItemAmount1ExtShield.text = itemInfo[0, 1].ToString();
            ItemCost1ExtShield.text = itemInfo[2, 1].ToString();
            ItemOwned1ExtShield.text = GameManagement.items[itemNumber].ToString();
        } else if (itemNumber == 2) {
            ItemAmount2TripShot.text = itemInfo[0, 2].ToString();
            ItemCost2TripShot.text = itemInfo[2, 2].ToString();
            ItemOwned2TripShot.text = GameManagement.items[itemNumber].ToString();
        } else if (itemNumber == 3) {
            ItemAmount3Wall.text = itemInfo[0, 3].ToString();
            ItemCost3Wall.text = itemInfo[2, 3].ToString();
            ItemOwned3Wall.text = GameManagement.items[itemNumber].ToString();
        } else if (itemNumber == 4) {
            ItemAmount4Supernova.text = itemInfo[0, 4].ToString();
            ItemCost4Supernova.text = itemInfo[2, 4].ToString();
            ItemOwned4Supernova.text = GameManagement.items[itemNumber].ToString();
        } else if (itemNumber == 5) {
            ItemAmount5Mine.text = itemInfo[0, 5].ToString();
            ItemCost5Mine.text = itemInfo[2, 5].ToString();
            ItemOwned5Mine.text = GameManagement.items[itemNumber].ToString();
        } else if (itemNumber == 6) {
            ItemAmount6Turret.text = itemInfo[0, 6].ToString();
            ItemCost6Turret.text = itemInfo[2, 6].ToString();
            ItemOwned6Turret.text = GameManagement.items[itemNumber].ToString();
        } else if (itemNumber == 7) {
            ItemAmount7OrbitBlades.text = itemInfo[0, 7].ToString();
            ItemCost7OrbitBlades.text = itemInfo[2, 7].ToString();
            ItemOwned7OrbitBlades.text = GameManagement.items[itemNumber].ToString();
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

        //GameManagement.money = 1000;
        moneyAvailable = GameObject.Find("MoneyAvailable").GetComponent<Text>();
        moneyAvailable.text = GameManagement.money.ToString();

        // Initialize text spaces
        ItemOwned0Health      = GameObject.Find("Item0Owned").GetComponent<Text>();
        ItemOwned1ExtShield   = GameObject.Find("Item1Owned").GetComponent<Text>();
        ItemOwned2TripShot    = GameObject.Find("Item2Owned").GetComponent<Text>();
        ItemOwned3Wall        = GameObject.Find("Item3Owned").GetComponent<Text>();
        ItemOwned4Supernova   = GameObject.Find("Item4Owned").GetComponent<Text>();
        ItemOwned5Mine        = GameObject.Find("Item5Owned").GetComponent<Text>();
        ItemOwned6Turret      = GameObject.Find("Item6Owned").GetComponent<Text>();
        ItemOwned7OrbitBlades = GameObject.Find("Item7Owned").GetComponent<Text>();

        // Initialize sprite array
        s1 = new Sprite[8];

        s1[0] = Resources.Load<Sprite>("Images/HealthButton");
        s1[1] = Resources.Load<Sprite>("Images/ExtendedShieldButton");
        s1[2] = Resources.Load<Sprite>("Images/TripleShotButton");
        s1[3] = Resources.Load<Sprite>("Images/WallButton");
        s1[4] = Resources.Load<Sprite>("Images/SupernovaButton");
        s1[5] = Resources.Load<Sprite>("Images/MineButton");
        s1[6] = Resources.Load<Sprite>("Images/TurretButton");
        s1[7] = Resources.Load<Sprite>("Images/OrbitalBladesButton");



        // Intialize item selection images
        I1 = GameObject.Find("ItemSlot1").GetComponent<Image>();
        I2 = GameObject.Find("ItemSlot2").GetComponent<Image>(); 
        I3 = GameObject.Find("ItemSlot3").GetComponent<Image>();
        I4 = GameObject.Find("ItemSlot4").GetComponent<Image>();

        // Set item selection images
        I1.sprite = s1[GameManagement.itemBar[0]];
        I2.sprite = s1[GameManagement.itemBar[1]];
        I3.sprite = s1[GameManagement.itemBar[2]];
        I4.sprite = s1[GameManagement.itemBar[3]];

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

        // Assign text fields
        ItemOwned0Health.text      = GameManagement.items[0].ToString();
        ItemOwned1ExtShield.text   = GameManagement.items[1].ToString();
        ItemOwned2TripShot.text    = GameManagement.items[2].ToString();
        ItemOwned3Wall.text        = GameManagement.items[3].ToString();
        ItemOwned4Supernova.text   = GameManagement.items[4].ToString();
        ItemOwned5Mine.text        = GameManagement.items[5].ToString();
        ItemOwned6Turret.text      = GameManagement.items[6].ToString();
        ItemOwned7OrbitBlades.text = GameManagement.items[7].ToString();
        moneyAvailable.text        = GameManagement.money.ToString();
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
