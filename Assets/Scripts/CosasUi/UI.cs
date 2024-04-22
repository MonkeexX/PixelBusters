using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused = false;
    public GameObject OptionsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Continue();
            }
            else
            {
                PauseMenu();
            }
        }
    }

    public void PauseMenu()
    {
        //PausePanel.SetActive(true);
        OptionsPanel.SetActive(false);
        //Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void Continue()
    {
        //PausePanel.SetActive(false);
        OptionsPanel.SetActive(false);
        //Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void OptionsMenu()
    {
        OptionsPanel.SetActive(true);
        PausePanel.SetActive(false);
    }
}