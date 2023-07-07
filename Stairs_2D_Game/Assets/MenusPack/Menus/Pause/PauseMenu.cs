using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader sceneFader;
    public int mainMenuIndex = 0;
    

    void PauseAllActions()
    {
        if (ui.activeSelf)
        {
            GameManager.Instance.isGamePaused = true;
            Time.timeScale = 0f;
          
        }
        else
        {
            GameManager.Instance.isGamePaused = false;
            Time.timeScale = 1f;
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo((SceneManager.GetActiveScene().buildIndex));
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(mainMenuIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
