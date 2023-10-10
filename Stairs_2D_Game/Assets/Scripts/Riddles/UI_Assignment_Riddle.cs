using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEditor;
using System;
using TMPro;


public class UI_Assignment_Riddle : MonoBehaviour
{
    public static UI_Assignment_Riddle Instance { get; private set; }
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject description; 
    [SerializeField] GameObject answer_1;
    [SerializeField] GameObject answer_2;
    [SerializeField] GameObject answer_3;
    [SerializeField] GameObject sprite;
    public Action OnAnsweredQuestion;
    public Action<string> OnWrongAnswer;
    public Action OnRightAnswer;
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
    void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
    }

    void SetupPanel(string description, string answer_1, string answer_2, string answer_3, Sprite sprite)
    {
        this.description.GetComponent<TextMeshProUGUI>().text = description;
        this.answer_1.GetComponentInChildren<TextMeshProUGUI>().text = answer_1;
        this.answer_2.GetComponentInChildren<TextMeshProUGUI>().text = answer_2;
        this.answer_3.GetComponentInChildren<TextMeshProUGUI>().text = answer_3;
        this.sprite.GetComponent<Image>().sprite = sprite;

        this.answer_1.GetComponent<AnswerButtonCheckerForRiddles>().SetRiddleIndex(0);
        this.answer_2.GetComponent<AnswerButtonCheckerForRiddles>().SetRiddleIndex(1);
        this.answer_3.GetComponent<AnswerButtonCheckerForRiddles>().SetRiddleIndex(2);
    }

    public void RaiseOnAnsweredQuestionEvent()
    {
        //OnAnsweredQuestion?.Invoke();
        OnRightAnswer?.Invoke();
    }

    public void RaiseOnWrongAnswerEvent()
    {
        int index = CardManager.selectedCard.assingnment.assignmentWithAnswers.IndexOfRightAnswer;
        OnWrongAnswer?.Invoke(CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index]);
        ResultsHandler.Instance.AddWrongAnswer(CardManager.selectedCard.cardGroupIndex);
        //ResultsHandler.Instance.AddWrongAnswer(CardManager.selectedCard.assignmentType);
    }
}
