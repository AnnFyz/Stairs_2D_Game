using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButtonCheckerForRiddles : MonoBehaviour
{
    [SerializeField] int riddleIndex;
    int secondIndex;
    int thirdIndex;
    public void SetRiddleIndex(int index)
    {
        riddleIndex = index;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetRiddleIndex(0);
            Debug.Log("riddleIndex: " + riddleIndex);
        }
    }
    public void CheckTheRiddle()
    {

        string text = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        int index = RiddleManager.selectedRiddle.riddle.indexesOfTheRightOption[0];
        if(RiddleManager.selectedRiddle.riddle.indexesOfTheRightOption.Length > 1)
        {
            secondIndex = RiddleManager.selectedRiddle.riddle.indexesOfTheRightOption[1];

            if (RiddleManager.selectedRiddle.riddle.indexesOfTheRightOption.Length > 2)
            {
                thirdIndex = RiddleManager.selectedRiddle.riddle.indexesOfTheRightOption[2];
                if (riddleIndex == index || riddleIndex == secondIndex || riddleIndex == thirdIndex)
                {
                    Debug.Log("currentRiddleIndex " + riddleIndex + " IndexOfRightAnswer " + index);
                    UI_Assignment_Riddle.Instance.RaiseOnOnRightAnswerEvent();
                }
                else
                {
                    Debug.Log("currentRiddleIndex: " + riddleIndex);
                    Debug.Log("Wrong Answer, the right answer: " + RiddleManager.selectedRiddle.riddle.indexesOfTheRightOption[0]);
                    UI_Assignment_Riddle.Instance.RaiseOnWrongAnswerEvent();
                }
            }
            else if (riddleIndex == index || riddleIndex == secondIndex)
            {
                Debug.Log("currentRiddleIndex " + riddleIndex + " IndexOfRightAnswer " + index);
                UI_Assignment_Riddle.Instance.RaiseOnOnRightAnswerEvent();
            }
            else
            {
                Debug.Log("currentRiddleIndex: " + riddleIndex);
                Debug.Log("Wrong Answer, the right answer: " + RiddleManager.selectedRiddle.riddle.indexesOfTheRightOption[0]);
                UI_Assignment_Riddle.Instance.RaiseOnWrongAnswerEvent();
            }
        }

        else if (riddleIndex == index)
        {
            Debug.Log("currentRiddleIndex " + riddleIndex + " IndexOfRightAnswer " + index);
            UI_Assignment_Riddle.Instance.RaiseOnOnRightAnswerEvent();
        }
        else 
        {
            Debug.Log("currentRiddleIndex: " + riddleIndex);
            Debug.Log("Wrong Answer, the right answer: " + RiddleManager.selectedRiddle.riddle.indexesOfTheRightOption[0]);
            UI_Assignment_Riddle.Instance.RaiseOnWrongAnswerEvent();
            //UI_Assignment_With_Answers.Instance.RaiseOnWrongAnswerEvent();
        }
    }
}
