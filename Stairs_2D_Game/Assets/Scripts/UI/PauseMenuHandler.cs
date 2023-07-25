using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] int sceneToLoad = 1;
    [SerializeField] GameObject Panel;

    private void Start()
    {
        DeactivatePanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivatePanel();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ActivatePanel()
    {
        Panel.SetActive(true);
    }

    public void DeactivatePanel()
    {
        Panel.SetActive(false);
    }
}
