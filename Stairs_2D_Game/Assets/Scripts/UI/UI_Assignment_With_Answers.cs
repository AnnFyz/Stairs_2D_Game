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
    public Action<string> OnWrongAnswer;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeactivateUIPanel();
        }
    }
    public void ActivateUIPanel(string question, string answer_1, string answer_2, string answer_3, Sprite sprite)
    {
        UIPanel.SetActive(true);
        SetupPanel(question, answer_1, answer_2, answer_3, sprite);

    }
    void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
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
        DeactivateUIPanel();
    }

    public void RaiseOnAnsweredQuestionEvent()
    {
        OnAnsweredQuestion?.Invoke();
    }

   public void RaiseOnWrongAnswerEvent()
    {
        int index = CardManager.selectedCard.assingnment.assignmentWithAnswers.IndexOfRightAnswer;
        OnWrongAnswer?.Invoke(CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index]);
        ResultsHandler.Instance.AddWrongAnswer(CardManager.selectedCard.assignmentType);
    }
}
