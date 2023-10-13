using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EndGame_Riddle : MonoBehaviour
{
    public static UI_EndGame_Riddle Instance { get; private set; }
    [SerializeField] GameObject UIPanel;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        RiddleManager.Instance.OnFinishedGame += ActivateUIPanel;
        DeactivateUIPanel();
    }

    public void ActivateUIPanel()
    {
        UIPanel.SetActive(true);
     
    }

    void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

}

