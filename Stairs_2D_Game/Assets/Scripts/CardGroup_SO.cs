using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;


public enum Assignment
{
    Assignment_With_Answer_Options,
    Assignment_With_Number_Input,
    Assignment_With_Text_Input,
    None

}

[System.Serializable]
public struct DiffAssignments
{
    public AssignmentWithAnswers_SO[] AssignmentsWithAnswers;
    public AssignmentWithUserInput_Numbers_SO[] AssignmentsWithUserInput_Number;
    public AssignmentWithUserInput_Text_SO[] AssignmentsWithUserInput_Text;

    public AssignmentWithAnswers_SO assignmentWithAnswers;
    public AssignmentWithUserInput_Numbers_SO assignmentWithUserInput_Number;
    public AssignmentWithUserInput_Text_SO assignmentWithUserInput_Text;

}
[CreateAssetMenu]
public class CardGroup_SO : ScriptableObject
{
    public string Title;
    //public int numberOfAssignmentGroup;
    //[Range(0, 100)]
    //public int Weight = 0;
    public Color groupColor;
    public Assignment TypeOfAssignment;
    public int currentAmountOfCardsOfThisType = 0;
    public DiffAssignments assignments;
    //public DiffAssignments randomAssignment;
    public bool allCardsWithAnswersWereCreated = false;
    public bool allCardsWithUserInput_Numbers_WereCreated = false;
    public bool allCardsWithUserInput_Text_WereCreated = false;
    public bool allCardsWereCreated = false;
    public AnimationCurve weightCurve;
    public int indexForAssignmentsWithAnswers = 0;
    public int indexForAssignmentsWithUserInput_Numbers = 0;
    public int indexForAssignmentsWithUserInput_Text = 0;
    public Action<Assignment, DiffAssignments> TimeToCreateCard;

    private void Awake()
    {
        assignments.assignmentWithAnswers = null;
        assignments.assignmentWithUserInput_Number = null;
        assignments.assignmentWithUserInput_Text = null;
        indexForAssignmentsWithAnswers = 0;
        indexForAssignmentsWithUserInput_Numbers = 0;
        indexForAssignmentsWithUserInput_Text = 0;
        currentAmountOfCardsOfThisType = 0;
        allCardsWithAnswersWereCreated = false;
        allCardsWithUserInput_Numbers_WereCreated = false;
        allCardsWithUserInput_Text_WereCreated = false;
        allCardsWereCreated = false;
    }

    public void OnDestroy()
    {
        assignments.assignmentWithAnswers = null;
        assignments.assignmentWithUserInput_Number = null;
        assignments.assignmentWithUserInput_Text = null;
        indexForAssignmentsWithAnswers = 0;
        indexForAssignmentsWithUserInput_Numbers = 0;
        indexForAssignmentsWithUserInput_Text = 0;
        currentAmountOfCardsOfThisType = 0;
        allCardsWithAnswersWereCreated = false;
        allCardsWithUserInput_Numbers_WereCreated = false;
        allCardsWithUserInput_Text_WereCreated = false;
        allCardsWereCreated = false;
        Debug.Log("OnDestroy");
    }
    private void OnEnable()
    {
       

        HandleStart();

    }

    private void OnDisable()
    {
        HandleStart();
    }


    public void HandleStart()
    {
        assignments.assignmentWithAnswers = null;
        assignments.assignmentWithUserInput_Number = null;
        assignments.assignmentWithUserInput_Text = null;
        indexForAssignmentsWithAnswers = 0;
        indexForAssignmentsWithUserInput_Numbers = 0;
        indexForAssignmentsWithUserInput_Text = 0;
        currentAmountOfCardsOfThisType = 0;
        allCardsWithAnswersWereCreated = false;
        allCardsWithUserInput_Numbers_WereCreated = false;
        allCardsWithUserInput_Text_WereCreated = false;
        allCardsWereCreated = false;
    }


    public void CalculateCurrentAmountOfCardsOfThisType()
    {
        currentAmountOfCardsOfThisType = assignments.AssignmentsWithAnswers.Length + assignments.AssignmentsWithUserInput_Number.Length + assignments.AssignmentsWithUserInput_Text.Length;
    }

    public void GetAssignment()
    {
        
        if (TypeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {
            SelectAssignmentWithAnswers();
        }
        else if (TypeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            SelectAssignmentWithUserInput_Number();
        }
        else if (TypeOfAssignment == Assignment.Assignment_With_Text_Input)
        {
            SelectAssignmentWithUserInput_Text();
        }

    }

    void SelectAssignmentWithAnswers()
    {
        if (indexForAssignmentsWithAnswers < assignments.AssignmentsWithAnswers.Length)
        {
            //Debug.Log("indexForAssignmentsWithAnswers " + indexForAssignmentsWithAnswers);
            assignments.assignmentWithAnswers = assignments.AssignmentsWithAnswers[indexForAssignmentsWithAnswers];
            indexForAssignmentsWithAnswers++;

        }
        if (indexForAssignmentsWithAnswers == assignments.AssignmentsWithAnswers.Length)
        {
            allCardsWithAnswersWereCreated = true;
            //assignments.assignmentWithAnswers = null;
            assignments.assignmentWithAnswers = assignments.AssignmentsWithAnswers[assignments.AssignmentsWithAnswers.Length-1];

        }
       

        //Debug.Log(" randomAssignment.assignmentWithAnswers " + randomAssignment.assignmentWithAnswers);

    }

    void SelectAssignmentWithUserInput_Number()
    {
        if (indexForAssignmentsWithUserInput_Numbers < assignments.AssignmentsWithUserInput_Number.Length)
        {
            //Debug.Log("indexForAssignmentsWithUserInput_Numbers " + indexForAssignmentsWithUserInput_Numbers);
            assignments.assignmentWithUserInput_Number = assignments.AssignmentsWithUserInput_Number[indexForAssignmentsWithUserInput_Numbers];
            indexForAssignmentsWithUserInput_Numbers++;

        }
        if (indexForAssignmentsWithUserInput_Numbers == assignments.AssignmentsWithUserInput_Number.Length)
        {
            allCardsWithUserInput_Numbers_WereCreated = true;
            //assignments.assignmentWithUserInput_Number = null;
            assignments.assignmentWithUserInput_Number = assignments.AssignmentsWithUserInput_Number[assignments.AssignmentsWithUserInput_Number.Length -1];
        }

        //Debug.Log("randomAssignment.assignmentWithUserInput_Number " + randomAssignment.assignmentWithUserInput_Number);

    }

    void SelectAssignmentWithUserInput_Text()
    {
        if (indexForAssignmentsWithUserInput_Text < assignments.AssignmentsWithUserInput_Text.Length)
        {
            //Debug.Log("indexForAssignmentsWithUserInput_Text " + indexForAssignmentsWithUserInput_Text);
            assignments.assignmentWithUserInput_Text = assignments.AssignmentsWithUserInput_Text[indexForAssignmentsWithUserInput_Text];
            indexForAssignmentsWithUserInput_Text++;
        }
        if (indexForAssignmentsWithUserInput_Text == assignments.AssignmentsWithUserInput_Text.Length)
        {
            allCardsWithUserInput_Text_WereCreated = true;
            //assignments.assignmentWithUserInput_Text = null;
            assignments.assignmentWithUserInput_Text = assignments.AssignmentsWithUserInput_Text[assignments.AssignmentsWithUserInput_Text.Length -1];
        }

        //Debug.Log("randomAssignment.assignmentWithUserInput_Text " + randomAssignment.assignmentWithUserInput_Text);

    }
}
