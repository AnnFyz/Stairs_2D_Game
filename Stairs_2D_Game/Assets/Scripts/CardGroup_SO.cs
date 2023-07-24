using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


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
    public int numberOfAssignmentGroup;
    [Range(0, 100)]
    public int Weight = 0;
    public Color groupColor;
    public Assignment TypeOfAssignment;
    public int currentAmountOfCardsOfThisType = 0;
    public DiffAssignments assignments;
    public DiffAssignments randomAssignment;
    public List<AssignmentWithAnswers_SO> givenAssignmentsWithAnswers;
    public List<AssignmentWithUserInput_Numbers_SO> givenAssignmentsUserInput_Number;
    public List<AssignmentWithUserInput_Text_SO> givenAssignmentsUserInput_Text;
    public bool allCardsWithAnswersWereCreated = false;
    public bool allCardsWithUserInput_Numbers_WereCreated = false;
    public bool allCardsWithUserInput_Text_WereCreated = false;
    public bool allCardsWereCreated = false;
    public AnimationCurve weightCurve;
    public int indexForAssignmentsWithAnswers = 0;
    public int indexForAssignmentsWithUserInput_Numbers = 0;
    public int indexForAssignmentsWithUserInput_Text = 0;

    private void OnEnable()
    {
        HandleStart();

    }

    //private void OnDisable()
    //{
    //    HandleStart();
    //}
    public void HandleStart()
    {
        randomAssignment.assignmentWithAnswers = null;
        randomAssignment.assignmentWithUserInput_Number = null;
        randomAssignment.assignmentWithUserInput_Text = null;
        givenAssignmentsWithAnswers.Clear();
        givenAssignmentsUserInput_Number.Clear();
        givenAssignmentsUserInput_Text.Clear();
        indexForAssignmentsWithAnswers = 0;
        indexForAssignmentsWithUserInput_Numbers = 0;
        indexForAssignmentsWithUserInput_Text = 0;
        currentAmountOfCardsOfThisType = 0;
        allCardsWithAnswersWereCreated = false;
        allCardsWithUserInput_Numbers_WereCreated = false;
        allCardsWithUserInput_Text_WereCreated = false;
        allCardsWereCreated = false;
        Debug.Log("HandleStart");
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
        if (TypeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            SelectAssignmentWithUserInput_Number();
        }
        if (TypeOfAssignment == Assignment.Assignment_With_Text_Input)
        {
            SelectAssignmentWithUserInput_Text();
        }

        Debug.Log("TypeOfAssignment " + TypeOfAssignment);
    }

    void SelectAssignmentWithAnswers()
    {
        if(indexForAssignmentsWithAnswers < assignments.AssignmentsWithAnswers.Length)
        {
            randomAssignment.assignmentWithAnswers = assignments.AssignmentsWithAnswers[indexForAssignmentsWithAnswers];
            indexForAssignmentsWithAnswers++;
        }       
        else 
        {
            allCardsWithAnswersWereCreated = true;
        }

        Debug.Log(" randomAssignment.assignmentWithAnswers " + randomAssignment.assignmentWithAnswers);
    }

    void SelectAssignmentWithUserInput_Number()
    {
        if (indexForAssignmentsWithUserInput_Numbers < assignments.AssignmentsWithUserInput_Number.Length)
        {
            randomAssignment.assignmentWithUserInput_Number = assignments.AssignmentsWithUserInput_Number[indexForAssignmentsWithUserInput_Numbers];
            indexForAssignmentsWithUserInput_Numbers++;
        }
        else
        {
            allCardsWithUserInput_Numbers_WereCreated = true;
        }

        Debug.Log("randomAssignment.assignmentWithUserInput_Number " + randomAssignment.assignmentWithUserInput_Number);
    }

    void SelectAssignmentWithUserInput_Text()
    {
        if (indexForAssignmentsWithUserInput_Text < assignments.AssignmentsWithUserInput_Text.Length)
        {
            randomAssignment.assignmentWithUserInput_Text = assignments.AssignmentsWithUserInput_Text[indexForAssignmentsWithUserInput_Text];
            indexForAssignmentsWithUserInput_Text++;
        }
        else
        {
            allCardsWithUserInput_Text_WereCreated = true;
        }

        Debug.Log("randomAssignment.assignmentWithUserInput_Text " + randomAssignment.assignmentWithUserInput_Text);
    }
}
//public void SetRandomAssignments()
//{
//    SelectRandomlyTypeOfAssignment();
//    DiffAssignments randomAssingnment = new DiffAssignments();

//    if (!allCardsWithAnswersWereCreated)
//    {
//        SelectRandomAssignmentWithAnswers(randomAssingnment);
//    }

//    if (!allCardsWithUserInput_Numbers_WereCreated)
//    {
//        SelectRandomAssignmentWithUserInput_Numbers(randomAssingnment);
//    }

//    if (!allCardsWithUserInput_Text_WereCreated)
//    {
//        SelectRandomAssignmentWithUserInput_Text(randomAssingnment);
//    }

//    if (givenAssignmentsWithAnswers.Count == assignments.AssignmentsWithAnswers.Length)
//    {
//        allCardsWithAnswersWereCreated = true;
//        if(!(givenAssignmentsUserInput_Number.Count == assignments.AssignmentsWithUserInput_Number.Length))
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Number_Input;
//            SelectRandomAssignmentWithUserInput_Numbers(randomAssingnment);
//        }
//        else if (givenAssignmentsUserInput_Number.Count == assignments.AssignmentsWithUserInput_Number.Length)
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Text_Input;
//            SelectRandomAssignmentWithUserInput_Text(randomAssingnment);
//        }        

//    }

//    if (givenAssignmentsUserInput_Number.Count == assignments.AssignmentsWithUserInput_Number.Length)
//    {
//        allCardsWithUserInput_Numbers_WereCreated = true;
//        if (!(givenAssignmentsWithAnswers.Count == assignments.AssignmentsWithAnswers.Length))
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
//            SelectRandomAssignmentWithAnswers(randomAssingnment);
//        }
//        else if (givenAssignmentsWithAnswers.Count == assignments.AssignmentsWithAnswers.Length)
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Text_Input;
//            SelectRandomAssignmentWithUserInput_Text(randomAssingnment);
//        }
//    }

//    if (givenAssignmentsUserInput_Number.Count == assignments.AssignmentsWithUserInput_Text.Length)
//    {
//        allCardsWithUserInput_Text_WereCreated = true;
//        if (!(givenAssignmentsWithAnswers.Count == assignments.AssignmentsWithAnswers.Length))
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
//            SelectRandomAssignmentWithAnswers(randomAssingnment);
//        }
//        else if (!(givenAssignmentsUserInput_Number.Count == assignments.AssignmentsWithUserInput_Number.Length))
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Number_Input;
//            SelectRandomAssignmentWithUserInput_Numbers(randomAssingnment);
//        }
//    }


//    if (allCardsWithUserInput_Numbers_WereCreated && allCardsWithAnswersWereCreated && allCardsWithUserInput_Text_WereCreated)
//    {
//        allCardsWereCreated = true;
//    }


//}

//public void SelectRandomlyTypeOfAssignment()
//{
//    int randomType = UnityEngine.Random.Range(0, 3);
//    switch (randomType)
//    {
//        case 0:
//            TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
//            break;
//        case 1:
//            TypeOfAssignment = Assignment.Assignment_With_Number_Input;
//            break;
//        case 3:
//            TypeOfAssignment = Assignment.Assignment_With_Text_Input;
//            break;
//    }       

//}

//void SelectRandomAssignmentWithAnswers(DiffAssignments randomAssingnment)
//{
//    if (TypeOfAssignment == Assignment.Assignment_With_Answer_Options)
//    {
//        for (int i = 0; i < assignments.AssignmentsWithAnswers.Length; i++)
//        {

//            randomAssingnment.assignmentWithAnswers = assignments.AssignmentsWithAnswers[UnityEngine.Random.Range(0, assignments.AssignmentsWithAnswers.Length)];


//            if (givenAssignmentsWithAnswers.Count == assignments.AssignmentsWithAnswers.Length)
//            {
//                allCardsWithAnswersWereCreated = true;

//            }

//            if (givenAssignmentsWithAnswers.Contains(randomAssingnment.assignmentWithAnswers) && !allCardsWithAnswersWereCreated)
//            {

//                while (givenAssignmentsWithAnswers.Contains(randomAssingnment.assignmentWithAnswers))
//                {
//                    randomAssingnment.assignmentWithAnswers = assignments.AssignmentsWithAnswers[UnityEngine.Random.Range(0, assignments.AssignmentsWithAnswers.Length)];
//                }
//            }

//            if (!allCardsWithAnswersWereCreated)
//            {
//                assignments.assignmentWithAnswers = randomAssingnment.assignmentWithAnswers;
//                givenAssignmentsWithAnswers.Add(randomAssingnment.assignmentWithAnswers);
//                break;
//            }



//        }


//    }
//}

//void SelectRandomAssignmentWithUserInput_Numbers(DiffAssignments randomAssingnment)
//{
//    if (TypeOfAssignment == Assignment.Assignment_With_Number_Input)
//    {
//        for (int i = 0; i < assignments.AssignmentsWithUserInput_Number.Length; i++)
//        {

//            randomAssingnment.assignmentWithUserInput_Number = assignments.AssignmentsWithUserInput_Number[UnityEngine.Random.Range(0, assignments.AssignmentsWithUserInput_Number.Length)];

//            if (givenAssignmentsUserInput_Number.Count == assignments.AssignmentsWithUserInput_Number.Length)
//            {
//                allCardsWithUserInput_Numbers_WereCreated = true;

//            }

//            if (givenAssignmentsUserInput_Number.Contains(randomAssingnment.assignmentWithUserInput_Number) && !allCardsWithUserInput_Numbers_WereCreated)
//            {

//                while (givenAssignmentsUserInput_Number.Contains(randomAssingnment.assignmentWithUserInput_Number))
//                {
//                    randomAssingnment.assignmentWithUserInput_Number = assignments.AssignmentsWithUserInput_Number[UnityEngine.Random.Range(0, assignments.AssignmentsWithUserInput_Number.Length)];
//                }
//            }

//            if (!allCardsWithUserInput_Numbers_WereCreated)
//            {
//                assignments.assignmentWithUserInput_Number = randomAssingnment.assignmentWithUserInput_Number;
//                givenAssignmentsUserInput_Number.Add(randomAssingnment.assignmentWithUserInput_Number);
//                break;
//            }

//        }
//    }
//}

//void SelectRandomAssignmentWithUserInput_Text(DiffAssignments randomAssingnment)
//{
//    if (TypeOfAssignment == Assignment.Assignment_With_Text_Input)
//    {
//        for (int i = 0; i < assignments.AssignmentsWithUserInput_Text.Length; i++)
//        {

//            randomAssingnment.assignmentWithUserInput_Text = assignments.AssignmentsWithUserInput_Text[UnityEngine.Random.Range(0, assignments.AssignmentsWithUserInput_Text.Length)];

//            if (givenAssignmentsUserInput_Text.Count == assignments.AssignmentsWithUserInput_Text.Length)
//            {
//                allCardsWithUserInput_Text_WereCreated = true;

//            }

//            if (givenAssignmentsUserInput_Text.Contains(randomAssingnment.assignmentWithUserInput_Text) && !allCardsWithUserInput_Text_WereCreated)
//            {

//                while (givenAssignmentsUserInput_Text.Contains(randomAssingnment.assignmentWithUserInput_Text))
//                {
//                    randomAssingnment.assignmentWithUserInput_Text = assignments.AssignmentsWithUserInput_Text[UnityEngine.Random.Range(0, assignments.AssignmentsWithUserInput_Text.Length)];
//                }
//            }

//            if (!allCardsWithUserInput_Text_WereCreated)
//            {
//                assignments.assignmentWithUserInput_Text = randomAssingnment.assignmentWithUserInput_Text;
//                givenAssignmentsUserInput_Text.Add(randomAssingnment.assignmentWithUserInput_Text);
//                break;
//            }

//        }
//    }
//}


//public void GetRandomAssignment()
//{
//    SelectRandomlyTypeOfAssignment();
//    if (TypeOfAssignment == Assignment.Assignment_With_Answer_Options)
//    {
//        GetRandomAssignmentWithAnswers();
//    }

//    if (TypeOfAssignment == Assignment.Assignment_With_Number_Input)
//    {
//        GetRandomAssignmentUserInput_Numbers();
//    }

//    if (TypeOfAssignment == Assignment.Assignment_With_Text_Input)
//    {
//        GetRandomAssignmentUserInput_Text();
//    }

//    if(givenAssignmentsWithAnswers.Count == 0 && givenAssignmentsUserInput_Number.Count == 0 && givenAssignmentsUserInput_Text.Count == 0)
//    {
//        Debug.Log("All Data was sent");
//    }

//}

//public void GetRandomAssignmentWithAnswers()
//{
//    if (TypeOfAssignment == Assignment.Assignment_With_Answer_Options)
//    {          
//        if (givenAssignmentsWithAnswers.Count == 0 && givenAssignmentsUserInput_Number.Count != 0)
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Number_Input;
//            GetRandomAssignmentUserInput_Numbers();
//        }

//        if (givenAssignmentsWithAnswers.Count == 0 && givenAssignmentsUserInput_Text.Count != 0)
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
//            GetRandomAssignmentUserInput_Text();
//        }

//        else if(givenAssignmentsWithAnswers.Count > 0)
//        {
//            int randomIndex = UnityEngine.Random.Range(0, givenAssignmentsWithAnswers.Count);
//            randomAssignment.assignmentWithAnswers = givenAssignmentsWithAnswers[randomIndex];
//            givenAssignmentsWithAnswers.Remove(givenAssignmentsWithAnswers[randomIndex]);
//        }
//    }
//}


//public void GetRandomAssignmentUserInput_Numbers()
//{
//    if (TypeOfAssignment == Assignment.Assignment_With_Number_Input )
//    {
//        if (givenAssignmentsUserInput_Number.Count == 0 && givenAssignmentsWithAnswers.Count != 0)
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
//            GetRandomAssignmentWithAnswers();
//        }

//        if (givenAssignmentsUserInput_Number.Count == 0 && givenAssignmentsUserInput_Text.Count != 0)
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
//            GetRandomAssignmentUserInput_Text();
//        }

//        else if(givenAssignmentsUserInput_Number.Count > 0)
//        {
//            int randomIndex = UnityEngine.Random.Range(0, givenAssignmentsUserInput_Number.Count);
//            randomAssignment.assignmentWithUserInput_Number = givenAssignmentsUserInput_Number[randomIndex];
//            givenAssignmentsUserInput_Number.Remove(givenAssignmentsUserInput_Number[randomIndex]);
//        }


//    }
//}

//public void GetRandomAssignmentUserInput_Text()
//{
//    if (TypeOfAssignment == Assignment.Assignment_With_Text_Input)
//    {
//        if (givenAssignmentsUserInput_Text.Count == 0 && givenAssignmentsWithAnswers.Count != 0)
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Answer_Options;
//            GetRandomAssignmentWithAnswers();
//        }

//        if (givenAssignmentsUserInput_Text.Count == 0 && givenAssignmentsUserInput_Number.Count != 0)
//        {
//            TypeOfAssignment = Assignment.Assignment_With_Number_Input;
//            GetRandomAssignmentUserInput_Numbers();
//        }

//        else if (givenAssignmentsUserInput_Text.Count > 0)
//        {
//            int randomIndex = UnityEngine.Random.Range(0, givenAssignmentsUserInput_Text.Count);
//            randomAssignment.assignmentWithUserInput_Text = givenAssignmentsUserInput_Text[randomIndex];
//            givenAssignmentsUserInput_Text.Remove(givenAssignmentsUserInput_Text[randomIndex]);
//        }


//    }
//}


//}
