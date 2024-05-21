using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Endgame_Puzzle : MonoBehaviour
{
    public static UI_Endgame_Puzzle Instance { get; private set; }
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
        PuzzleManager.Instance.OnFinishedGame += ActivateUIPanel;
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
