using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class PopUpWindow : MonoBehaviour
{
    public static PopUpWindow Instance;
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject rightAnswerObj;
    [SerializeField] string answerText = "";
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


    }

    private void OnEnable()
    {
        answerText = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;

    }
    private void Start()
    {
        UI_Assignment_WithInput.Instance.OnWrongAnswer += SetupPopUpWindowForUserInput;
        UI_Assignment_With_Answers.Instance.OnWrongAnswer += SetupPopUpWindowForAnswerOptions;
        DeactivateUIPanel();
    }

     void SetupPopUpWindowForUserInput(float rightAnswer)
    {
        ActivateUIPanel();
        answerText = rightAnswer.ToString();
    }

     void SetupPopUpWindowForAnswerOptions(string rightAnswer)
    {
        ActivateUIPanel();
        answerText = rightAnswer;
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
