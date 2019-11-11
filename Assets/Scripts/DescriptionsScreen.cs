using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DescriptionsScreen : MonoBehaviour {
    public void mainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void itemShop() {
        SceneManager.LoadScene("Shop Screen");
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
