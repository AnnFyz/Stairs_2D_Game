using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum Assignment
{
    Assignment_With_Answer_Options,
    Assignment_With_Number_Input
}
[CreateAssetMenu]
public class CardGroup_SO : ScriptableObject
{
    [SerializeField] string Title;
    public int numberOfAssignmentGroup;
    [Range(0, 100)]
    public int Weight = 0;
    public Color groupColor;
    public Assignment currentTypeOfAssignment; // STATIC??
    public int currentAmountOfCardsOfThisType = 0;
    public System.Object[] AssignmentsArray;
    public UnityEngine.Object[] AssignmentArrayUnity;

   
    public void CalculateCurrentAmountOfCardsOfThisType ()
    {
        AssignmentsArray = AssignmentArrayUnity;
        for (int i = 0; i < AssignmentArrayUnity.Length; i++)
        {
            AssignmentsArray[i] = AssignmentArrayUnity[i];
        }
        for (int i = 0; i < AssignmentsArray.Length; i++)
        {
           
                Array array = AssignmentsArray[i] as Array;

                currentAmountOfCardsOfThisType += array.Length;
            

        }
    }
    public void SelectRandomAssignment()
    {
        System.Object assignmentArray = AssignmentArrayUnity[UnityEngine.Random.Range(0, AssignmentArrayUnity.Length)];

        if(Types.Equals(assignmentArray.GetType(), typeof(Assignments_Array_WithAnswers_SO)))
        {
            currentTypeOfAssignment = Assignment.Assignment_With_Answer_Options;
            Debug.Log("Was selected Assignment with Answers");
        }

        if (Types.Equals(assignmentArray.GetType(), typeof(Assignments_Array_WithUserInput_Numbers_SO)))
        {
            currentTypeOfAssignment = Assignment.Assignment_With_Number_Input;
            Debug.Log("Was selected Assignment with Numbers");
        }
    }
}
