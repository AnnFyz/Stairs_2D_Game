using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButtonCheckerForAssignmentsWithAnswers : MonoBehaviour
{
    [SerializeField] int cardIndex = -1;

    public void SetCardIndex(int index)
    {
        cardIndex = index;
    }

    public void CheckTheCard()
    {

        string text = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        int index = CardManager.selectedCard.assingnment.assignmentWithAnswers.IndexOfRightAnswer;
        //Debug.Log("Text on the button:" + text);
        //if (cardIndex == CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index])
        if (cardIndex == index)
        {
            Debug.Log("cardIndex " + cardIndex + " IndexOfRightAnswer " + index);
            UI_Assignment_With_Answers.Instance.RaiseOnAnsweredQuestionEvent();
        }
        //else if (cardIndex != CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index])
        else if (cardIndex != index)
        {
            Debug.Log("cardIndex " + cardIndex + "IndexOfRightAnswer " + index);
            //Debug.Log("Wrong Answer, the right answer: " + CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index]);
            UI_Assignment_With_Answers.Instance.RaiseOnWrongAnswerEvent();
        }
    }
}
