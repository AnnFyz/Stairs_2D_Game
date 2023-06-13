using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public Assignment assignmentType;
    public DiffAssignments assingnment;
    public static CardController Create(Transform prefabCard, CardGroup_SO cardGroup, Transform parent)
    {
        Transform cardObj = Instantiate(prefabCard);
        cardObj.transform.SetParent(parent);
        cardObj.GetComponentInChildren<Image>().color = cardGroup.groupColor;
        CardController card = prefabCard.GetComponent<CardController>();
        Canvas.ForceUpdateCanvases();
        return card;
    }

    public void Setup(CardGroup_SO group , DiffAssignments randomAssignment)
    {
        assignmentType = group.TypeOfAssignment;
        assingnment = randomAssignment;
    }
    //public void Setup(CardGroup_SO group, DiffAssignments assignments)
    //{
    //    if(group.currentTypeOfAssignment == Assignment.Assignment_With_Answer_Options)
    //    {
    //        // take an assignment and fill ui with data 
    //        //group.SelectRandomAssignment();
    //        assingnment.assignmentWithAnswers = assignments.assignmentWithAnswers;
    //        assignmentType = group.TypeOfAssignment;
    //       // Debug.Log("UI of Card: Assignment_With_Answer_Options");
    //    }

    //    if (group.currentTypeOfAssignment == Assignment.Assignment_With_Number_Input)
    //    {
    //        // take an assignment and fill ui with data 
    //        //group.SelectRandomAssignment();
    //        assingnment.assignmentWithUserInput = assignments.assignmentWithUserInput;
    //        assignmentType = group.TypeOfAssignment;
    //        //Debug.Log("UI of Card: Assignment_With_Number_Input");
    //    }
    //}

}
