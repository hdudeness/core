﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public void backButton()
    {
        SceneManager.LoadScene("MainMenu"); // Back button puts user at main menu screen.
    }
}
