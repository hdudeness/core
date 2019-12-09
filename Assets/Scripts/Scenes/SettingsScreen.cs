using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScreen : MonoBehaviour
{
    public double volumeFromSettings = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;

    public void backButton()
    {
        SceneManager.LoadScene("MainMenu"); // Back button puts user at main menu screen.
    }

    void Update() 
    {
        GameManagement.volume = volumeFromSettings;
    }
}
