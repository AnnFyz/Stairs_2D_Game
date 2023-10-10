using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class LinkHandler : MonoBehaviour
{
    public static LinkHandler Instance { get; private set; }
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject linkObj;
    [SerializeField] TextMeshProUGUI link_tmp;
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


        link_tmp = linkObj.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        DeactivateUIPanel();
    }
    public void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
    }

    public void OpenURL()
    {
        
        Application.OpenURL(PuzzleManager.Instance.GetCurrentPuzzleSO().URL);
        
    }
    public void ActivateUIPanel()
    {
        link_tmp.text = PuzzleManager.Instance.GetCurrentPuzzleSO().nameOfPuzzle;
        UIPanel.SetActive(true);
    }


}
