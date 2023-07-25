using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] int sceneToLoad = 1;
    [SerializeField] GameObject modePanel;

    private void Start()
    {
        DeactivatePanel();
    }
    public void Play()
    {
        SceneManager.LoadScene(sceneToLoad);

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ActivatePanel()
    {
        modePanel.SetActive(true);
    }

    public void DeactivatePanel()
    {
        modePanel.SetActive(false);
    }
}
