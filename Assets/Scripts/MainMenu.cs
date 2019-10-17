using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("PlayScreen");   //Load PlayScreen scene in the scene index
    }

    public void loadGame()
    {
        SceneManager.LoadScene("LoadScreen");
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
