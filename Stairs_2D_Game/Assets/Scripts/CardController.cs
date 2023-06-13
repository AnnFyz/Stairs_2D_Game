using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public Assignment assignmentType;
    public DiffAssignments assingnment;
    public GameObject UIPanel;
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



    public void ActivateUIPanel()
    {
        if(assignmentType == Assignment.Assignment_With_Answer_Options)
        {
            UI_Assignment_With_Answers.Instance.ActivateUIPanel(assingnment.assignmentWithAnswers.Question, assingnment.assignmentWithAnswers.Answers[0], assingnment.assignmentWithAnswers.Answers[1], assingnment.assignmentWithAnswers.Answers[2]);
        }
        if (assignmentType == Assignment.Assignment_With_Number_Input)
        {
            UI_Assignment_WithInput.Instance.ActivateUIPanel(assingnment.assignmentWithUserInput.Question);
        }
    }
}
