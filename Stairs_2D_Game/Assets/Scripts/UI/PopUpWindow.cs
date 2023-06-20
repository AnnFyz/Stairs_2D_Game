using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour
{
    public static PopUpWindow Instance;
    [SerializeField] GameObject UIPanel;
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
        UI_Assignment_WithInput.Instance.OnWrongAnswer += SetupPopUpWindowForUserInput;
        UI_Assignment_With_Answers.Instance.OnWrongAnswer += SetupPopUpWindowForAnswerOptions;
        UIPanel.SetActive(false);
    }

 
    void SetupPopUpWindowForUserInput(float rightAnswer)
    {
        ActivateUIPanel();
        answer_tmp.text = rightAnswer.ToString();
    }

     void SetupPopUpWindowForAnswerOptions(string rightAnswer)
    {
        ActivateUIPanel();
        answer_tmp.text = rightAnswer;
    }

    void ActivateUIPanel()
    {
        UIPanel.SetActive(true);
    }
    public void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
        OnClosedPopUpWindow?.Invoke();
    }

}
