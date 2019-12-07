using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Items : MonoBehaviour
{
    public HealthManagement health;
    public Supernova nova;
    public WallItem wallItem;

    public Sprite[] s;

    public Image I1;
    public Image I2;
    public Image I3;
    public Image I4;

    public Text slot1Amount;
    public Text slot2Amount;
    public Text slot3Amount;
    public Text slot4Amount;

    public void useItem( int slot) {
        int item = GameManagement.itemBar[slot];
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
    }

    public void healthRestore() {
        health.updateCoreHealth(-10);
    }

    public void extendedShield() {
        print("ES");
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

    public void mine() {
        print("M");
    }

    public void turret() {
        print("T");
    }

    public void orbitalBlades() {
        print("OB");
    }

    // Start is called before the first frame update
    void Start() {
        I1.sprite = s[GameManagement.itemBar[0]];
        I2.sprite = s[GameManagement.itemBar[1]];
        I3.sprite = s[GameManagement.itemBar[2]];
        I4.sprite = s[GameManagement.itemBar[3]];

        slot1Amount.text = GameManagement.items[GameManagement.itemBar[0]].ToString();
        slot2Amount.text = GameManagement.items[GameManagement.itemBar[1]].ToString();
        slot3Amount.text = GameManagement.items[GameManagement.itemBar[2]].ToString();
        slot4Amount.text = GameManagement.items[GameManagement.itemBar[3]].ToString();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
