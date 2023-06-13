using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public Assignment assignmentType;
    public AssignmentWithAnswers_SO assignmentWithAnswers;
    public AssignmentWithUserInput_Numbers_SO assignmentWithUserInput;
    public static CardController Create(Transform prefabCard, CardGroup_SO cardGroup, Transform parent)
    {
        Transform cardObj = Instantiate(prefabCard);
        cardObj.transform.SetParent(parent);
        cardObj.GetComponentInChildren<Image>().color = cardGroup.groupColor;
        CardController card = prefabCard.GetComponent<CardController>();
        Canvas.ForceUpdateCanvases();
        return card;
    }

    public void Setup(CardGroup_SO group)
    {
        if(group.currentTypeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {
            // take an assignment and fill ui with data 
            //group.SelectRandomAssignment();
            assignmentWithAnswers = group.assignments.assignmentWithAnswers;
            //assignmentType = group.currentTypeOfAssignment;
           // Debug.Log("UI of Card: Assignment_With_Answer_Options");
        }

        if (group.currentTypeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            // take an assignment and fill ui with data 
            //group.SelectRandomAssignment();
            assignmentWithUserInput = group.assignments.assignmentWithUserInput;
            //assignmentType = group.currentTypeOfAssignment;
            //Debug.Log("UI of Card: Assignment_With_Number_Input");
        }
    }

}
