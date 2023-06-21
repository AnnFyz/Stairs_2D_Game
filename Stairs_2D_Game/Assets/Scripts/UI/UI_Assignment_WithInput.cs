using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Globalization;

public class UI_Assignment_WithInput : MonoBehaviour
{
    public static UI_Assignment_WithInput Instance { get; private set; }
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject question; // for TextMeshPro
    [SerializeField] GameObject inputFieldObj; // for InputField
    public float savedUserInput;
    TMP_InputField tmpInputField;
    public Action OnAnsweredQuestion;
    public Action <float> OnWrongAnswer;
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

        tmpInputField = inputFieldObj.GetComponent<TMP_InputField>();
    }
    private void Start()
    {
        DeactivateUIPanel();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SaveUserInput();
            CheckUserInput();
            UIPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeactivateUIPanel();
        }
    }
    public void ActivateUIPanel(string question)
    {
        UIPanel.SetActive(true);
        ClearUIPanel();
        SetupPanel(question);
    }

    void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
    }

    void ClearUIPanel()
    {
        tmpInputField.text = "";
    }
     void SetupPanel(string question)
    {
        this.question.GetComponent<TextMeshProUGUI>().text = question;
    }

    void SaveUserInput()
    {
        try
        {
            savedUserInput = float.Parse(tmpInputField.text, new CultureInfo("de-DE"));
            if (tmpInputField.text != null)
            {
                Debug.Log(inputFieldObj.GetComponent<TMP_InputField>().text);
            }
        }

        catch (Exception e)
        {
            savedUserInput = Mathf.Infinity;
            RaiseOnWrongAnswerEvent();
            //  Block of code to handle errors
        }

    }

 
    void RaiseOnAnsweredQuestionEvent()
    {
        OnAnsweredQuestion?.Invoke();
    }
    void RaiseOnWrongAnswerEvent()
    {
        OnWrongAnswer?.Invoke(CardManager.selectedCard.assingnment.assignmentWithUserInput.RightNumber);
    }

    void CheckUserInput()
    {
        if(savedUserInput == CardManager.selectedCard.assingnment.assignmentWithUserInput.RightNumber)
        {
            Debug.Log("Right Answer");
            RaiseOnAnsweredQuestionEvent();
        }
        else if (savedUserInput != CardManager.selectedCard.assingnment.assignmentWithUserInput.RightNumber)
        {
            Debug.Log("Wrong Answer, the right answer: " + CardManager.selectedCard.assingnment.assignmentWithUserInput.RightNumber);
            RaiseOnWrongAnswerEvent();
        }
    }

    
}
