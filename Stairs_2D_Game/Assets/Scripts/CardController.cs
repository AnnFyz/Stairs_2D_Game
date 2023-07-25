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
    public int cardGroupIndex;


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

    public void Setup(CardGroup_SO group, Assignment typeOfAssignment, DiffAssignments assignments, int index)
    {
        assignmentType = typeOfAssignment;
        assingnment = assignments;
        this.GetComponentInChildren<Image>().color = group.groupColor;
        //cardGroupIndex = group.numberOfAssignmentGroup;
        cardGroupIndex = index;
    }



    public void ActivateUIPanel()
    {
        if (this == CardManager.selectedCard)
        {


            if (assignmentType == Assignment.Assignment_With_Answer_Options && assingnment.assignmentWithAnswers != null)
            {
                UI_Assignment_With_Answers.Instance.ActivateUIPanel(assingnment.assignmentWithAnswers.Question, assingnment.assignmentWithAnswers.Answers[0], assingnment.assignmentWithAnswers.Answers[1], assingnment.assignmentWithAnswers.Answers[2], assingnment.assignmentWithAnswers.sprite);

            }
            else if (assignmentType == Assignment.Assignment_With_Number_Input)
            {
                UI_Assignment_WithInput.Instance.ActivateUIPanel(assingnment.assignmentWithUserInput_Number.Question, assingnment.assignmentWithUserInput_Number.sprite);

            }
            else if (assignmentType == Assignment.Assignment_With_Text_Input)
            {
                UI_Assignment_WithInput.Instance.ActivateUIPanel(assingnment.assignmentWithUserInput_Text.Question, assingnment.assignmentWithUserInput_Text.sprite);

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

    public void DestroyCard()
    {

        Destroy(gameObject);

    }
}