using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_Assignment_WithInput : MonoBehaviour
{
    public static UI_Assignment_WithInput Instance { get; private set; }
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject question; // for TextMeshPro
    [SerializeField] GameObject inputFieldObj; // for InputField
    public Action OnAnsweredQuestion;
    public float savedUserInput;
    TMP_InputField tmpInputField;
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
            RaiseOnAnsweredQuestionEvent();
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
        savedUserInput = float.Parse(tmpInputField.text);
        if (tmpInputField.text != null)
        {
            Debug.Log(inputFieldObj.GetComponent<TMP_InputField>().text);
        }

    }

 
    void RaiseOnAnsweredQuestionEvent()
    {
        OnAnsweredQuestion?.Invoke();
    }
    void CheckUserInput()
    {
        if(savedUserInput == CardManager.selectedCard.assingnment.assignmentWithUserInput.RightNumber)
        {
            Debug.Log("Right Answer");
        }
        else if (savedUserInput != CardManager.selectedCard.assingnment.assignmentWithUserInput.RightNumber)
        {
            Debug.Log("Wrong Answer");
        }
    }
}
