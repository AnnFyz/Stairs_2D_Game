using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum Assignment
{
    Assignment_With_Answer_Options,
    Assignment_With_Number_Input,
    Assignment_With_Text_Input

}

[System.Serializable]
public struct DiffAssignments
{
    public AssignmentWithAnswers_SO[] AssignmentsWithAnswers;
    public AssignmentWithUserInput_Numbers_SO[] AssignmentsWithUserInput_Number;
    public AssignmentWithUserInput_Text_SO[] AssignmentsWithUserInput_Text;

    public AssignmentWithAnswers_SO assignmentWithAnswers;
    public AssignmentWithUserInput_Numbers_SO assignmentWithUserInput_Number;
    public AssignmentWithUserInput_Text_SO assignmentsWithUserInput_Text;

}
[CreateAssetMenu]
public class CardGroup_SO : ScriptableObject
{
    [SerializeField] string Title;
    public int numberOfAssignmentGroup;
    [Range(0, 100)]
    public int Weight = 0;
    public Color groupColor;
    public Assignment TypeOfAssignment;
    public int currentAmountOfCardsOfThisType = 0;
    public DiffAssignments assignments;
    public DiffAssignments randomAssignment;
    public List<AssignmentWithAnswers_SO> givenAssignmentsWithAnswers;
    public List<AssignmentWithUserInput_Numbers_SO> givenAssignmentsUserInput;
    public bool allCardsWithAnswersWereCreated = false;
    public bool allCardsWithUserInputWereCreated = false;
    public bool allCardsWereCreated = false;
    public AnimationCurve weightCurve;

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
        currentAmountOfCardsOfThisType = assignments.AssignmentsWithAnswers.Length + assignments.AssignmentsWithUserInput_Number.Length;
    }

    public void SetRandomAssignments()
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
            TypeOfAssignment = Assignment.Assignment_With_Number_Input;
            SelectRandomAssignmentWithUserInput(randomAssingnment);

        }

        if (givenAssignmentsUserInput.Count == assignments.AssignmentsWithUserInput_Number.Length)
        {
            allCardsWithUserInputWereCreated = true;
            TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
            SelectRandomAssignmentWithAnswers(randomAssingnment);

        }


        if (allCardsWithUserInputWereCreated && allCardsWithAnswersWereCreated)
        {
            allCardsWereCreated = true;
        }


    }

    public void SelectRandomlyTypeOfAssignment()
    {
        int randomType = UnityEngine.Random.Range(0, 2);
        switch (randomType)
        {
            case 0:
                TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
                break;
            case 1:
                TypeOfAssignment = Assignment.Assignment_With_Number_Input;
                break;
        }

    }

    void SelectRandomAssignmentWithAnswers(DiffAssignments randomAssingnment)
    {
        if (TypeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {
            for (int i = 0; i < assignments.AssignmentsWithAnswers.Length; i++)
            {

                randomAssingnment.assignmentWithAnswers = assignments.AssignmentsWithAnswers[UnityEngine.Random.Range(0, assignments.AssignmentsWithAnswers.Length)];


                if (givenAssignmentsWithAnswers.Count == assignments.AssignmentsWithAnswers.Length)
                {
                    allCardsWithAnswersWereCreated = true;

                }

                if (givenAssignmentsWithAnswers.Contains(randomAssingnment.assignmentWithAnswers) && !allCardsWithAnswersWereCreated)
                {

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
        if (TypeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            for (int i = 0; i < assignments.AssignmentsWithUserInput_Number.Length; i++)
            {

                randomAssingnment.assignmentWithUserInput_Number = assignments.AssignmentsWithUserInput_Number[UnityEngine.Random.Range(0, assignments.AssignmentsWithUserInput_Number.Length)];

                if (givenAssignmentsUserInput.Count == assignments.AssignmentsWithUserInput_Number.Length)
                {
                    allCardsWithUserInputWereCreated = true;

                }

                if (givenAssignmentsUserInput.Contains(randomAssingnment.assignmentWithUserInput_Number) && !allCardsWithUserInputWereCreated)
                {

                    while (givenAssignmentsUserInput.Contains(randomAssingnment.assignmentWithUserInput_Number))
                    {
                        randomAssingnment.assignmentWithUserInput_Number = assignments.AssignmentsWithUserInput_Number[UnityEngine.Random.Range(0, assignments.AssignmentsWithUserInput_Number.Length)];
                    }
                }

                if (!allCardsWithUserInputWereCreated)
                {
                    assignments.assignmentWithUserInput_Number = randomAssingnment.assignmentWithUserInput_Number;
                    givenAssignmentsUserInput.Add(randomAssingnment.assignmentWithUserInput_Number);
                    break;
                }

            }
        }
    }

    public void GetRandomAssignment()
    {
        SelectRandomlyTypeOfAssignment();
        if (TypeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {
            GetRandomAssignmentWithAnswers();
        }

        if (TypeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            GetRandomAssignmentUserInput();
        }

        if(givenAssignmentsWithAnswers.Count == 0 && givenAssignmentsUserInput.Count == 0)
        {
            Debug.Log("All Data was sent");
        }

    }

    public void GetRandomAssignmentWithAnswers()
    {
        if (TypeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {          
            if (givenAssignmentsWithAnswers.Count == 0 && givenAssignmentsUserInput.Count != 0)
            {
                TypeOfAssignment = Assignment.Assignment_With_Number_Input;
                GetRandomAssignmentUserInput();
            }
            else if(givenAssignmentsWithAnswers.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, givenAssignmentsWithAnswers.Count);
                randomAssignment.assignmentWithAnswers = givenAssignmentsWithAnswers[randomIndex];
                givenAssignmentsWithAnswers.Remove(givenAssignmentsWithAnswers[randomIndex]);
            }
        }
    }


    public void GetRandomAssignmentUserInput()
    {
        if (TypeOfAssignment == Assignment.Assignment_With_Number_Input )
        {
            if (givenAssignmentsUserInput.Count == 0 && givenAssignmentsWithAnswers.Count != 0)
            {
                TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
                GetRandomAssignmentWithAnswers();
            }
            else if(givenAssignmentsUserInput.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, givenAssignmentsUserInput.Count);
                randomAssignment.assignmentWithUserInput_Number = givenAssignmentsUserInput[randomIndex];
                givenAssignmentsUserInput.Remove(givenAssignmentsUserInput[randomIndex]);
            }
            
            
        }
    }
   
}
