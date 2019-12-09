using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static bool isLoaded = false;
    public static string playerName = "";

    public void playGame()
    {
        playerName = GameObject.Find("InputFieldName").GetComponent<InputField>().text.ToString();
        PauseResume.isPaused = false;
        isLoaded = false;
        SceneManager.LoadScene("InGame");
    }

    public void mainManu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadGame()
    {
        /*PauseResume.isPaused = false;
        isLoaded = true;
        SceneManager.LoadScene("InGame");*/
        SceneManager.LoadScene("Shop Screen");
    }

    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void quit()
    {
        Application.Quit();
    }
}
