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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("riddleIndex: " + riddleIndex);
        }
    }
    public void CheckTheRiddle()
    {

        string text = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        int index = RiddleManager.selectedRiddle.riddle.indexOfTheRightOption;
        int secondIndex = RiddleManager.selectedRiddle.riddle.indexOfTheSecondRightOption;
        int thirdIndex = RiddleManager.selectedRiddle.riddle.indexOfTheThirdRightOption;
        if (riddleIndex == index) //|| currentRiddleIndex == secondIndex || currentRiddleIndex == thirdIndex)
        {
            Debug.Log("currentRiddleIndex " + riddleIndex + " IndexOfRightAnswer " + index);
            UI_Assignment_Riddle.Instance.RaiseOnOnRightAnswerEvent();
            //UI_Assignment_With_Answers.Instance.RaiseOnAnsweredQuestionEvent();
        }
        //else if (cardIndex != CardManager.selectedCard.assingnment.assignmentWithAnswers.Answers[index])
        else if (riddleIndex != index && riddleIndex != secondIndex && riddleIndex != thirdIndex)
        {
            Debug.Log("currentRiddleIndex: " + riddleIndex);
            Debug.Log("Wrong Answer, the right answer: " + RiddleManager.selectedRiddle.riddle.indexOfTheRightOption);
            UI_Assignment_Riddle.Instance.RaiseOnWrongAnswerEvent();
            //UI_Assignment_With_Answers.Instance.RaiseOnWrongAnswerEvent();
        }
    }
}
