using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameScript : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
