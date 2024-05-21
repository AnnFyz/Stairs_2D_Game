using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PuzzleRightAnswer : MonoBehaviour
{
    public static UI_PuzzleRightAnswer Instance { get; private set; }
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
        DeactivateUIPanel();
    }
    public void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
    }
    public void ActivateUIPanel()
    {
        UIPanel.SetActive(true);
    }

}
