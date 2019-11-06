﻿using System.Collections;
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
        isLoaded = false;
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
