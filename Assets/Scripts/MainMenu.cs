using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool isLoaded = false;

    public void playGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void mainManu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadGame()
    {
        isLoaded = true;
        SceneManager.LoadScene("InGame");
    }

    public void settings()
    {
        SceneManager.LoadScene("SetScreen");
    }

    public void quit()
    {
        Application.Quit();
    }
}
