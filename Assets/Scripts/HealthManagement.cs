using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HealthManagement : MonoBehaviour
{
    public int coreHealth = 100;
    public Text txtHealth;
    public bool godMode = false;
    public GameManagement gameManagement;

    // Method for changing core health. Positive values are damage, and
    // negative values are healing.
    public void updateCoreHealth(int dmg)
    {
        if (!godMode)
        {
            coreHealth -= dmg;
            if(txtHealth != null)
            {
                txtHealth.text = Convert.ToString(coreHealth) + "%";
            }
            if (coreHealth <= 0)
            {

                SceneManager.LoadScene("LoseScene");
                gameManagement.Saver();
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        updateCoreHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
