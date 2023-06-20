using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButtonCheckerForAssignmentsWithAnswers : MonoBehaviour
{
    public void CheckTheCard()
    {
        string text = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        int index = CardManager.selectedCard.assingnment.assignmentWithAnswers.IndexOfRightAnswer;
        Debug.Log("Text on the button:" + text);
        if (text == CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index])
        {
            Debug.Log("Right Answer");
            UI_Assignment_With_Answers.Instance.RaiseOnAnsweredQuestionEvent();
        }
        else if (text != CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index])
        {
            Debug.Log("Wrong Answer, the right answer: " + CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index]);
            UI_Assignment_With_Answers.Instance.RaiseOnWrongAnswerEvent();
        }
    }
}
