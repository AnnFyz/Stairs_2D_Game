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
    public bool allCardsWithAnswersWereCreated = false;
    public bool allCardsWithUserInputWereCreated = false;
    public bool allCardsWereCreated = false;

    private void OnEnable()
    {
        currentAmountOfCardsOfThisType = 0;
        givenAssignmentsWithAnswers.Clear();
        givenAssignmentsUserInput.Clear();
        allCardsWithAnswersWereCreated = false;
        allCardsWithUserInputWereCreated = false;
        allCardsWereCreated = false;

    }

    public void CalculateCurrentAmountOfCardsOfThisType()
    {
        currentAmountOfCardsOfThisType = assignments.AssignmentsWithAnswers.Length + assignments.AssignmentsWithUserInput.Length;
    }

    public void SelectRandomAssignment()
    {
        SelectRandomlyTypeOfAssignment();
        DiffAssignments randomAssingnment = new DiffAssignments();

        if (!allCardsWithAnswersWereCreated)
        {
            SelectRandomAssignmentWithAnswers(randomAssingnment);
        }

        if (!allCardsWithUserInputWereCreated)
        {
            SelectRandomAssignmentWithUserInput(randomAssingnment);
        }

        if (givenAssignmentsWithAnswers.Count == assignments.AssignmentsWithAnswers.Length)
        {
            allCardsWithAnswersWereCreated = true;
            currentTypeOfAssignment = Assignment.Assignment_With_Number_Input;
            SelectRandomAssignmentWithUserInput(randomAssingnment);

            Debug.Log("allCardsWithAnswersWereCreated");

        }

        if (givenAssignmentsUserInput.Count == assignments.AssignmentsWithUserInput.Length)
        {
            allCardsWithUserInputWereCreated = true;
            currentTypeOfAssignment = Assignment.Assignment_With_Answer_Options;
            SelectRandomAssignmentWithAnswers(randomAssingnment);
            Debug.Log("allCardsWithUserInputWereCreated");

        }


        if (allCardsWithUserInputWereCreated && allCardsWithAnswersWereCreated)
        {
            Debug.Log("All assignments were distributed");
            allCardsWereCreated = true;
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

    void SelectRandomAssignmentWithAnswers(DiffAssignments randomAssingnment)
    {
        if (currentTypeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {
            for (int i = 0; i < assignments.AssignmentsWithAnswers.Length; i++)
            {

                randomAssingnment.assignmentWithAnswers = assignments.AssignmentsWithAnswers[UnityEngine.Random.Range(0, assignments.AssignmentsWithAnswers.Length)];
                Debug.Log("(currentTypeOfAssignment == Assignment.Assignment_With_Answer_Options");
                

                if (givenAssignmentsWithAnswers.Count == assignments.AssignmentsWithAnswers.Length)
                {
                    allCardsWithAnswersWereCreated = true;
                    //currentTypeOfAssignment = Assignment.Assignment_With_Number_Input;
                    //Debug.Log("allCardsWithAnswersWereCreated");
                    //break;
                }

                if (givenAssignmentsWithAnswers.Contains(randomAssingnment.assignmentWithAnswers) && !allCardsWithAnswersWereCreated)
                {
                    // i--; // endless loop crushes the programm 
                    //continue;
                    //SelectRandomAssignmentWithAnswers(randomAssingnment);
                    while (givenAssignmentsWithAnswers.Contains(randomAssingnment.assignmentWithAnswers))
                    {
                        randomAssingnment.assignmentWithAnswers = assignments.AssignmentsWithAnswers[UnityEngine.Random.Range(0, assignments.AssignmentsWithAnswers.Length)];
                    }
                }

                if (!allCardsWithAnswersWereCreated)
                {
                    assignments.assignmentWithAnswers = randomAssingnment.assignmentWithAnswers;
                    givenAssignmentsWithAnswers.Add(randomAssingnment.assignmentWithAnswers);
                    break;
                }



            }


        }
    }

    void SelectRandomAssignmentWithUserInput(DiffAssignments randomAssingnment)
    {
        if (currentTypeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            for (int i = 0; i < assignments.AssignmentsWithUserInput.Length; i++)
            {

                randomAssingnment.assignmentWithUserInput = assignments.AssignmentsWithUserInput[UnityEngine.Random.Range(0, assignments.AssignmentsWithUserInput.Length)];
                Debug.Log("currentTypeOfAssignment == Assignment.Assignment_With_Number_Input");

                if (givenAssignmentsUserInput.Count == assignments.AssignmentsWithUserInput.Length)
                {
                    allCardsWithUserInputWereCreated = true;
                    //currentTypeOfAssignment = Assignment.Assignment_With_Answer_Options;
                    //Debug.Log("allCardsWithUserInputWereCreated");
                    // break;
                }

                if (givenAssignmentsUserInput.Contains(randomAssingnment.assignmentWithUserInput) && !allCardsWithUserInputWereCreated)
                {
                    //i--;
                    //continue;
                    //SelectRandomAssignmentWithUserInput(randomAssingnment);
                    while (givenAssignmentsUserInput.Contains(randomAssingnment.assignmentWithUserInput))
                    {
                        randomAssingnment.assignmentWithUserInput = assignments.AssignmentsWithUserInput[UnityEngine.Random.Range(0, assignments.AssignmentsWithUserInput.Length)];
                    }
                }

                if (!allCardsWithUserInputWereCreated)
                {
                    assignments.assignmentWithUserInput = randomAssingnment.assignmentWithUserInput;
                    givenAssignmentsUserInput.Add(randomAssingnment.assignmentWithUserInput);
                    break;
                }

            }
        }
    }
}
