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
    [SerializeField] GameObject inputField; // for InputField
    public Action OnAnsweredQuestion;
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
        UIPanel.SetActive(false);
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
            UIPanel.SetActive(false);
        }
    }
    public void ActivateUIPanel(string question)
    {
        UIPanel.SetActive(true);
        SetupPanel(question);
    }
     void SetupPanel(string question)
    {
        this.question.GetComponent<TextMeshProUGUI>().text = question;
    }

    void SaveUserInput()
    {
        if (inputField.GetComponent<TMP_InputField>().text != null)
        {
            Debug.Log(inputField.GetComponent<TMP_InputField>().text);
        }

    }

 
    void RaiseOnAnsweredQuestionEvent()
    {
        OnAnsweredQuestion?.Invoke();
        Debug.Log("OnAnsweredQuestion?.Invoke();");
    }
    void CheckUserInput()
    {

    }
}
