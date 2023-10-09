using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PopUpEnd : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    private void Start()
    {
        DeactivatePanel();
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
