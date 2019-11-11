using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ShopScene : MonoBehaviour
{
    public void mainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void descriptions() {
        SceneManager.LoadScene("Descriptions Screen");
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
