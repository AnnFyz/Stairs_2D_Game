using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Riddles_PopUpWindow : MonoBehaviour
{
    public static Riddles_PopUpWindow Instance;
    [SerializeField] GameObject UIPanelForWrongObj;
    [SerializeField] GameObject UIPanelForRightObj;
    [SerializeField] GameObject rightAnswerObj;
    [SerializeField] TextMeshProUGUI answer_tmp;
    public Action OnClosedPopUpWindow;


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

        answer_tmp = rightAnswerObj.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {


    }
    private void Start()
    {
        UI_Assignment_Riddle.Instance.OnWrongAnswer += SetupPopUpWindowForWrongAnswer;
        UI_Assignment_Riddle.Instance.OnRightAnswer += SetupWindowForRightAnswer;

        UIPanelForWrongObj.SetActive(false);
        UIPanelForRightObj.SetActive(false);
    }


 
    void SetupPopUpWindowForWrongAnswer(string rightAnswer)
    {
        ActivateUIPanelForWrongAnswer();
        answer_tmp.text = rightAnswer;
    }

    void SetupWindowForRightAnswer()
    {
        ActivateUIPanelForRightAnswer();
    }

    void ActivateUIPanelForWrongAnswer()
    {
        UIPanelForWrongObj.SetActive(true);
    }

    void ActivateUIPanelForRightAnswer()
    {
        UIPanelForRightObj.SetActive(true);
    }
    public void DeactivateUIPanelForWrongAnswer()
    {
        UIPanelForWrongObj.SetActive(false);
        OnClosedPopUpWindow?.Invoke();
    }

    public void DeactivateUIPanelForRightAnswer()
    {
        UIPanelForRightObj.SetActive(false);
        OnClosedPopUpWindow?.Invoke();
    }

}
