using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Lore");
    }

    public void Salir()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}