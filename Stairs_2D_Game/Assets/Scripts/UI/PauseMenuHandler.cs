using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] int sceneToLoad = 1;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject Logos;
    private void Start()
    {
        DeactivatePanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
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
        Logos.SetActive(true);
    }

    public void DeactivatePanel()
    {
        Panel.SetActive(false);
        Logos.SetActive(false);
    }
}
