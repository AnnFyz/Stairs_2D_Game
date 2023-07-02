using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public Assignment assignmentType;
    public DiffAssignments assingnment;
    public GameObject UIPanel;
    public bool isCardActivated = false;
    public bool isCardDeactivared = false;

    private void Start()
    {
        if (this != CardManager.selectedCard)
        {
            gameObject.GetComponent<Button>().interactable = false;
            isCardActivated = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            isCardActivated = true;
        }
    }
    public static CardController Create(Transform prefabCard, CardGroup_SO cardGroup, Transform parent)
    {
        Transform cardObj = Instantiate(prefabCard);
        cardObj.transform.SetParent(parent);
        cardObj.GetComponentInChildren<Image>().color = cardGroup.groupColor;
        CardController card = prefabCard.GetComponent<CardController>();
        Canvas.ForceUpdateCanvases();
        return card;
    }

    public void Setup(CardGroup_SO group, DiffAssignments randomAssignment)
    {
        assignmentType = group.TypeOfAssignment;
        assingnment = randomAssignment;
    }



    public void ActivateUIPanel()
    {
        if (this == CardManager.selectedCard)
        {

            if (assignmentType == Assignment.Assignment_With_Answer_Options)
            {
                UI_Assignment_With_Answers.Instance.ActivateUIPanel(assingnment.assignmentWithAnswers.Question, assingnment.assignmentWithAnswers.Answers[0], assingnment.assignmentWithAnswers.Answers[1], assingnment.assignmentWithAnswers.Answers[2], assingnment.assignmentWithAnswers.sprite);
            }
            if (assignmentType == Assignment.Assignment_With_Number_Input)
            {
                UI_Assignment_WithInput.Instance.ActivateUIPanel(assingnment.assignmentWithUserInput_Number.Question, assingnment.assignmentWithUserInput_Number.sprite);
            }
        }
    }

    public void ActivateCard()
    {
        if (this == CardManager.selectedCard)
        {
            gameObject.GetComponent<Button>().interactable = true;
            isCardActivated = true;
        }
    }

    public void DeactivateCard()
    {
       
            gameObject.GetComponent<Button>().interactable = false;
            isCardActivated = false;
       
    }
}
