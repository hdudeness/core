using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Items : MonoBehaviour
{
    public HealthManagement health;
    public Supernova nova;
    public BladeOrbit bladeOrbit;
    public WallItem wallItem;
    public MineItem mineItem;
    public ExtendedShield shield;

    public Sprite[] s1;

    public Image I1;
    public Image I2;
    public Image I3;
    public Image I4;

    public Text slot1Amount;
    public Text slot2Amount;
    public Text slot3Amount;
    public Text slot4Amount;

    public void useItem(int slot) {
        int item = GameManagement.itemBar[slot];
        if (GameManagement.items[item] > 0) {
            if (item == 0) {
                healthRestore();
            } else if (item == 1) {
                extendedShield();
            } else if (item == 2) {
                tripleShot();
            } else if (item == 3) {
                wall();
            } else if (item == 4) {
                supernova();
            } else if (item == 5) {
                mine();
            } else if (item == 6) {
                turret();
            } else if (item == 7) {
                orbitalBlades();
            }

            GameManagement.items[item]--;

            if (slot == 0) {
                slot1Amount.text = GameManagement.items[item].ToString();
            } else if (slot == 1) {
                slot2Amount.text = GameManagement.items[item].ToString();
            } else if (slot == 2) {
                slot3Amount.text = GameManagement.items[item].ToString();
            } else if (slot == 3) {
                slot4Amount.text = GameManagement.items[item].ToString();
            }
        }
    }

    public void healthRestore() {
        health.updateCoreHealth(-10);
    }

    public void extendedShield() {
        ExtendedShield newExtendedShield = Instantiate(shield, GameObject.Find("Shield").transform.position, Quaternion.identity);
    }

    public void tripleShot() {
        print("TS");
    }
    
    public void wall() {
        // Spawn an instance of the wall prefab.
        print("W");
    }
    
    public void supernova() {
        Supernova newNova = Instantiate(nova, new Vector3(0f, 0f, 0), Quaternion.identity);
    }


    public void orbitalBlades()
    {
        BladeOrbit newBladeOrbit = Instantiate(bladeOrbit, new Vector3(5f, 5f, 0), Quaternion.identity);
    }
	
    public void mine() {
        print("M");
    }

    public void turret() {
        print("T");
    }


    // Start is called before the first frame update
    void Start() {
        // Instantiate s[]
        s1 = new Sprite[8];

        s1[0] = Resources.Load<Sprite>("Images/HealthButton");
        s1[1] = Resources.Load<Sprite>("Images/ExtendedShieldButton");
        s1[2] = Resources.Load<Sprite>("Images/TripleShotButton");
        s1[3] = Resources.Load<Sprite>("Images/WallButton");
        s1[4] = Resources.Load<Sprite>("Images/SupernovaButton");
        s1[5] = Resources.Load<Sprite>("Images/MineButton");
        s1[6] = Resources.Load<Sprite>("Images/TurretButton");
        s1[7] = Resources.Load<Sprite>("Images/OrbitalBladesButton");
        
        I1 = GameObject.Find("Item1").GetComponent<Image>();
        I2 = GameObject.Find("Item2").GetComponent<Image>();
        I3 = GameObject.Find("Item3").GetComponent<Image>();
        I4 = GameObject.Find("Item4").GetComponent<Image>();

        I1.sprite = s1[GameManagement.itemBar[0]];
        I2.sprite = s1[GameManagement.itemBar[1]];
        I3.sprite = s1[GameManagement.itemBar[2]];
        I4.sprite = s1[GameManagement.itemBar[3]];

        slot1Amount = GameObject.Find("Slot1Amount").GetComponent<Text>();
        slot2Amount = GameObject.Find("Slot2Amount").GetComponent<Text>();
        slot3Amount = GameObject.Find("Slot3Amount").GetComponent<Text>();
        slot4Amount = GameObject.Find("Slot4Amount").GetComponent<Text>();

        slot1Amount.text = GameManagement.items[GameManagement.itemBar[0]].ToString();
        slot2Amount.text = GameManagement.items[GameManagement.itemBar[1]].ToString();
        slot3Amount.text = GameManagement.items[GameManagement.itemBar[2]].ToString();
        slot4Amount.text = GameManagement.items[GameManagement.itemBar[3]].ToString();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
