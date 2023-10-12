using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButtonCheckerForRiddles : MonoBehaviour
{
    [SerializeField] int riddleIndex = -1;

    public void SetRiddleIndex(int index)
    {
        riddleIndex = index;
    }

    public void CheckTheRiddle()
    {

        string text = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        int index = RiddleManager.selectedRiddle.riddle.indexOfTheRightOption;
        int secondIndex = RiddleManager.selectedRiddle.riddle.indexOfTheSecondRightOption;
        if (riddleIndex == index || riddleIndex == secondIndex)
        {
            Debug.Log("riddleIndex " + riddleIndex + " IndexOfRightAnswer " + index);
            UI_Assignment_Riddle.Instance.RaiseOnAnsweredQuestionEvent();
            //UI_Assignment_With_Answers.Instance.RaiseOnAnsweredQuestionEvent();
        }
        //else if (cardIndex != CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index])
        else if (riddleIndex != index && riddleIndex != secondIndex)
        {
            Debug.Log("riddleIndex " + riddleIndex + "IndexOfRightAnswer " + index);
            Debug.Log("Button " + this);
            //Debug.Log("Wrong Answer, the right answer: " + CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index]);
            UI_Assignment_Riddle.Instance.RaiseOnAnsweredQuestionEvent();
            //UI_Assignment_With_Answers.Instance.RaiseOnWrongAnswerEvent();
        }
    }
}
