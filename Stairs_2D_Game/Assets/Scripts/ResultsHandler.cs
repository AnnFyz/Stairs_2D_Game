using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsHandler : MonoBehaviour
{
    [SerializeField] GameObject UIPanel;
    [SerializeField] Transform group_TextPref;
    [SerializeField] Transform textObject;

    public static ResultsHandler Instance { get; private set; }
    [SerializeField] int amountOfWrongAnswers_AssignmentsWithAnswers;
    [SerializeField] int amountOfWrongAnswers_AssignmentsUserInput_Numbers;
    [SerializeField] int amountOfWrongAnswers_AssignmentsUserInput_Text;

    [SerializeField] int amountOfAllAnswers_AssignmentsWithAnswers;
    [SerializeField] int amountOfAllgAnswers_AssignmentsUserInput_Numbers;
    [SerializeField] int amountOfAllAnswers_AssignmentsUserInput_Text;

    [SerializeField] float PercentageOfInsolvedAssignmentsWithAnswers;
    [SerializeField] float PercentageOfInsolvedAssignmentsWithUserInput_Numbers;
    [SerializeField] float PercentageOfInsolvedAssignmentsWithUserInput_Text;


    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        CardManager.Instance.OnFinishedGame += CalculatePercentageOfUnsolvedAssignments;
        CalculateAmountOfGroupsPref();
    }

    public void CalculateAmountOfGroupsPref()
    {
        foreach (var group in CardManager.Instance.CardGroups)
        {
            Transform textObj = Instantiate(group_TextPref);
            textObj.transform.SetParent(textObject.transform);
        }
    }
    public void AddWrongAnswer(Assignment typeOfAssignment)
    {
        if (typeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {
            amountOfWrongAnswers_AssignmentsWithAnswers++;
        }
        if (typeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            amountOfWrongAnswers_AssignmentsUserInput_Numbers++;
        }
        if (typeOfAssignment == Assignment.Assignment_With_Text_Input)
        {
            amountOfWrongAnswers_AssignmentsUserInput_Text++;
        }
    }

    public void CalculateAmountOfAllAnswers()
    {
        for (int i = 0; i < CardManager.Instance.reorginizedCards.Length; i++)
        {
            if (CardManager.Instance.reorginizedCards[i].assignmentType == Assignment.Assignment_With_Answer_Options)
            {
                amountOfAllAnswers_AssignmentsWithAnswers++;
            }
            if (CardManager.Instance.reorginizedCards[i].assignmentType == Assignment.Assignment_With_Number_Input)
            {
                amountOfAllgAnswers_AssignmentsUserInput_Numbers++;
            }
            if (CardManager.Instance.reorginizedCards[i].assignmentType == Assignment.Assignment_With_Text_Input)
            {
                amountOfAllAnswers_AssignmentsUserInput_Text++;
            }
        }
    }

    public void CalculatePercentageOfUnsolvedAssignments()
    {
        PercentageOfInsolvedAssignmentsWithAnswers = amountOfWrongAnswers_AssignmentsWithAnswers * (amountOfAllAnswers_AssignmentsWithAnswers * 0.01f);
        PercentageOfInsolvedAssignmentsWithUserInput_Numbers = amountOfWrongAnswers_AssignmentsUserInput_Numbers * (amountOfAllgAnswers_AssignmentsUserInput_Numbers * 0.01f);
        PercentageOfInsolvedAssignmentsWithUserInput_Text = amountOfWrongAnswers_AssignmentsUserInput_Text * (amountOfAllAnswers_AssignmentsUserInput_Text * 0.01f);
    }
    void SetupPanel()
    {
    }

        void ActivateUIPanel()
    {
        UIPanel.SetActive(true);
    }
    public void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
    }

}
