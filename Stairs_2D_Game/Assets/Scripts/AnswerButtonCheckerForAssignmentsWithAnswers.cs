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
        }
        else if (text != CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index])
        {
            Debug.Log("Wrong Answer");
        }
    }
}
