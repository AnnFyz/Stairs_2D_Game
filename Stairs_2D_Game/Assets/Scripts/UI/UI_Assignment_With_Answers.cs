using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_Assignment_With_Answers : MonoBehaviour
{
    public static UI_Assignment_With_Answers Instance { get; private set; }
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject question; // for TextMeshPro
    [SerializeField] GameObject answer_1;
    [SerializeField] GameObject answer_2;
    [SerializeField] GameObject answer_3;
    [SerializeField] GameObject sprite;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIPanel.SetActive(false);
        }
    }
    public void ActivateUIPanel(string question, string answer_1, string answer_2, string answer_3, Sprite sprite)
    {
        UIPanel.SetActive(true);
        SetupPanel(question, answer_1, answer_2, answer_3, sprite);

    }
    void SetupPanel(string question, string answer_1, string answer_2, string answer_3, Sprite sprite)
    {
        this.question.GetComponent<TextMeshProUGUI>().text = question;
        this.answer_1.GetComponentInChildren<TextMeshProUGUI>().text = answer_1;
        this.answer_2.GetComponentInChildren<TextMeshProUGUI>().text = answer_2;
        this.answer_3.GetComponentInChildren<TextMeshProUGUI>().text = answer_3;
        this.sprite.GetComponent<Image>().sprite = sprite;
    }

   public void SelectAnswer()
    {
        UIPanel.SetActive(false);
        RaiseOnAnsweredQuestionEvent();
        CheckUserInput();

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
