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
    public float savedUserInputNumber;
    public string savedUserInputText;
    TMP_InputField tmpInputField;
    public Action OnAnsweredQuestion;
    public Action <string> OnWrongAnswer;
    [SerializeField] GameObject sprite;
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
            if(CardManager.selectedCard.assignmentType == Assignment.Assignment_With_Number_Input)
            {
                UserInputWithNumbersHandler();
                Debug.Log("UserInputWithNumbersHandler");
            }
            else if (CardManager.selectedCard.assignmentType == Assignment.Assignment_With_Text_Input)
            {
                UserInputWithTextHandler();
                Debug.Log(" UserInputWithTextHandler");
            }
            UIPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeactivateUIPanel();
        }
    }
    public void ActivateUIPanel(string question, Sprite sprite)
    {
        UIPanel.SetActive(true);
        ClearUIPanel();
        SetupPanel(question, sprite);
    }

    void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
    }

    void ClearUIPanel()
    {
        tmpInputField.text = "";
    }
     void SetupPanel(string question, Sprite sprite)
    {
        this.question.GetComponent<TextMeshProUGUI>().text = question;
        this.sprite.GetComponent<Image>().sprite = sprite;
    }

    void UserInputWithNumbersHandler()
    {
        SaveUserInputWithNumbers();
        CheckUserInputWithNumbers();
    }
    void SaveUserInputWithNumbers()
    {
        try
        {
            savedUserInputNumber = float.Parse(tmpInputField.text, new CultureInfo("de-DE"));
            if (tmpInputField.text != null)
            {
                Debug.Log(inputFieldObj.GetComponent<TMP_InputField>().text);
            }
        }

        catch (Exception e)
        {
            savedUserInputNumber = Mathf.Infinity;
            //  Block of code to handle errors
        }

    }

 
    void RaiseOnAnsweredQuestionEvent()
    {
        OnAnsweredQuestion?.Invoke();
    }
    void RaiseOnWrongAnswerEvent()
    {
        if (CardManager.selectedCard.assignmentType == Assignment.Assignment_With_Number_Input)
        {
            OnWrongAnswer?.Invoke(CardManager.selectedCard.assingnment.assignmentWithUserInput_Number.RightNumber.ToString());
            //ResultsHandler.Instance.AddWrongAnswer(CardManager.selectedCard.assignmentType);
            ResultsHandler.Instance.AddWrongAnswer(CardManager.selectedCard.cardGroupIndex);
        }

        else if (CardManager.selectedCard.assignmentType == Assignment.Assignment_With_Text_Input)
        {
            OnWrongAnswer?.Invoke(CardManager.selectedCard.assingnment.assignmentWithUserInput_Text.RightAnswer);
            //ResultsHandler.Instance.AddWrongAnswer(CardManager.selectedCard.assignmentType);
            ResultsHandler.Instance.AddWrongAnswer(CardManager.selectedCard.cardGroupIndex);
        }

    }

    void CheckUserInputWithNumbers()
    {
        if(savedUserInputNumber == CardManager.selectedCard.assingnment.assignmentWithUserInput_Number.RightNumber)
        {
            //Debug.Log("Right Answer  (numbers)");
            RaiseOnAnsweredQuestionEvent();
        }
        else if (savedUserInputNumber != CardManager.selectedCard.assingnment.assignmentWithUserInput_Number.RightNumber)
        {
            //Debug.Log("Wrong Answer  (numbers), the right answer: " + CardManager.selectedCard.assingnment.assignmentWithUserInput_Number.RightNumber);
            RaiseOnWrongAnswerEvent();
        }
    }

    void UserInputWithTextHandler()
    {
        SaveUserInputWithText();
        CheckUserInputWithText();
    }

    void SaveUserInputWithText()
    {
        savedUserInputText = tmpInputField.text.ToString();
    }

    void CheckUserInputWithText()
    {
        if (savedUserInputText == CardManager.selectedCard.assingnment.assignmentWithUserInput_Text.RightAnswer)
        {
            //Debug.Log("Right Answer (text)");
            RaiseOnAnsweredQuestionEvent();
        }
        else if (savedUserInputText != CardManager.selectedCard.assingnment.assignmentWithUserInput_Text.RightAnswer)
        {
            //Debug.Log("Wrong Answer (text), the right answer: " + CardManager.selectedCard.assingnment.assignmentWithUserInput_Text.RightAnswer);
            RaiseOnWrongAnswerEvent();
        }
    }
}
