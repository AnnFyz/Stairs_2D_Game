using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum Assignment
{
    Assignment_With_Answer_Options,
    Assignment_With_Number_Input
}

[System.Serializable]
public struct DiffAssignments
{
    public AssignmentWithAnswers_SO[] AssignmentsWithAnswers;
    public AssignmentWithUserInput_Numbers_SO[] AssignmentsWithUserInput;

    public AssignmentWithAnswers_SO assignmentWithAnswers;
    public AssignmentWithUserInput_Numbers_SO assignmentWithUserInput;
}
[CreateAssetMenu]
public class CardGroup_SO : ScriptableObject
{
    [SerializeField] string Title;
    public int numberOfAssignmentGroup;
    [Range(0, 100)]
    public int Weight = 0;
    public Color groupColor;
    public Assignment currentTypeOfAssignment;
    public int currentAmountOfCardsOfThisType = 0;
    public DiffAssignments assignments;
    public List<AssignmentWithAnswers_SO> givenAssignmentsWithAnswers;
    public List<AssignmentWithUserInput_Numbers_SO> givenAssignmentsUserInput;
    public bool allCardWithAnswersWereCreated = false;
    public bool allCardWithUserInputWereCreated = false;
    public bool allCardsWereCreated = false;

    public void CalculateCurrentAmountOfCardsOfThisType()
    {
        currentAmountOfCardsOfThisType = assignments.AssignmentsWithAnswers.Length + assignments.AssignmentsWithUserInput.Length;
    }


    public void SelectRandomAssignment()
    {
        SelectRandomlyTypeOfAssignment();
        DiffAssignments randomAssingnment;
        if (currentTypeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {
            for (int i = 0; i < assignments.AssignmentsWithAnswers.Length; i++)
            {

                randomAssingnment.assignmentWithAnswers = assignments.AssignmentsWithAnswers[UnityEngine.Random.Range(0, assignments.AssignmentsWithAnswers.Length)];
                if (givenAssignmentsWithAnswers.Contains(randomAssingnment.assignmentWithAnswers))
                {
                    continue;
                }

                else if (givenAssignmentsWithAnswers.Count == assignments.AssignmentsWithAnswers.Length)
                {
                    allCardWithAnswersWereCreated = true;
                }

                else
                {
                    assignments.assignmentWithAnswers = randomAssingnment.assignmentWithAnswers;
                    givenAssignmentsWithAnswers.Add(randomAssingnment.assignmentWithAnswers);
                    break;
                }
                
            }
           

        }

        if (currentTypeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            assignments.assignmentWithUserInput = assignments.AssignmentsWithUserInput[UnityEngine.Random.Range(0, assignments.AssignmentsWithUserInput.Length)];

        }
        Debug.Log("Select random assignment");
    }

    public void SelectRandomlyTypeOfAssignment()
    {
        int randomType = UnityEngine.Random.Range(0, 2);
        switch (randomType)
        {
            case 0:
                currentTypeOfAssignment = Assignment.Assignment_With_Answer_Options;
                break;
            case 1:
                currentTypeOfAssignment = Assignment.Assignment_With_Number_Input;
                break;
        }

    }
}
