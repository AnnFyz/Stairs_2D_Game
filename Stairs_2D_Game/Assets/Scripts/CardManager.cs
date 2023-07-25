using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    public Transform prefabCard;
    public CardGroup_SO[] CardGroups;
    int AmountOfCardsToInstantiate = 0;
    [SerializeField] CardController[] createdCards;
    public static CardController selectedCard;
    public CardController currentselectedCard;
    [SerializeField] int indexOfSelectedCard = 0;
    [SerializeField] bool wasOpenedAllCards = false;
    public CardController[] reorginizedCards;
    public Action OnFinishedGame;

    int groupIndex = 0;

    [SerializeField] DiffAssignments allAssignments;
    public int indexForAssignmentsWithAnswers = 0;
    public int indexForAssignmentsWithUserInput_Numbers = 0;
    public int indexForAssignmentsWithUserInput_Text = 0;

    public bool allCardsWithAnswersWereCreated = false;
    public bool allCardsWithUserInput_Numbers_WereCreated = false;
    public bool allCardsWithUserInput_Text_WereCreated = false;

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
    void OnEnable()
    {
        UI_Assignment_WithInput.Instance.OnAnsweredQuestion += SelectNextCard; 
        UI_Assignment_With_Answers.Instance.OnAnsweredQuestion += SelectNextCard;
        PopUpWindow.Instance.OnClosedPopUpWindow += SelectNextCard;
    }

    private void OnDisable()
    {
        UI_Assignment_WithInput.Instance.OnAnsweredQuestion -= SelectNextCard; 
        UI_Assignment_With_Answers.Instance.OnAnsweredQuestion -= SelectNextCard;
        PopUpWindow.Instance.OnClosedPopUpWindow -= SelectNextCard;
    }

    private void Start()
    {
     
        HandleStart(); 
    }

    public void HandleStart()
    {
        groupIndex = 0;

        for (int i = 0; i < CardGroups.Length; i++)
        {
            CardGroups[i].HandleStart();
        }
        CalculateCurrentAmountOfCardsInTheGroup();
        CalculateAmountOfCardsToInstantiate();
        SetupCards();

        //CheckTheFirstCard();
        AddAllCreatedCards();
       // ReorganizeCreatedCards();
        //selectedCard = reorginizedCards[0];
        ResultsHandler.Instance.CalculateAmountOfAllAnswers();
    }

  
    public void DeleteCards()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<CardController>().DestroyCard();
        }
    }
   
    void CalculateCurrentAmountOfCardsInTheGroup()
    {

        for (int i = 0; i < CardGroups.Length; i++)
        {
            CardGroups[i].CalculateCurrentAmountOfCardsOfThisType();
        }
    }
    void CalculateAmountOfCardsToInstantiate()
    {
        foreach (var group in CardGroups)
        {

            AmountOfCardsToInstantiate += group.currentAmountOfCardsOfThisType;
        }
    }
    void SetupCards()
    {
        CardController card;

        if (CardGroups.Length > 0)
        {
            

            foreach (var group in CardGroups)
            {
                

                AddAllAssignments(group);

                for (int i = 0; i < group.currentAmountOfCardsOfThisType; i++)
                {
                    //GetAssignment(group, i);
                    group.GetAssignment();
                    card = CardController.Create(prefabCard, transform);
                    card.Setup(group, group.TypeOfAssignment, group.assignments);                  

                }

                if (groupIndex < CardGroups.Length)
                {
                    groupIndex++;
                }
            }
        }

    }

    void CreateCards()
    {

    }

    void AddAllAssignments(CardGroup_SO group)
    {
      

        if (group.TypeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {
            Debug.Log("Add  " + Assignment.Assignment_With_Answer_Options);
            allAssignments.AssignmentsWithAnswers = group.assignments.AssignmentsWithAnswers;
        }
        if (group.TypeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            Debug.Log("Add  " + Assignment.Assignment_With_Number_Input);
            allAssignments.AssignmentsWithUserInput_Number = group.assignments.AssignmentsWithUserInput_Number;
        }
        if (group.TypeOfAssignment == Assignment.Assignment_With_Text_Input)
        {
            Debug.Log("Add  " + Assignment.Assignment_With_Text_Input);
            allAssignments.AssignmentsWithUserInput_Text = group.assignments.AssignmentsWithUserInput_Text;
        }
    }


    public void GetAssignment(CardGroup_SO group, int index)
    {
        if (group.TypeOfAssignment == Assignment.Assignment_With_Answer_Options)
        {
            SelectAssignmentWithAnswers(index);
        }
        else if (group.TypeOfAssignment == Assignment.Assignment_With_Number_Input)
        {
            SelectAssignmentWithUserInput_Number(index);
        }
        else if (group.TypeOfAssignment == Assignment.Assignment_With_Text_Input)
        {
            SelectAssignmentWithUserInput_Text(index);
        }

    }

    void SelectAssignmentWithAnswers(int index)
    {
        if (indexForAssignmentsWithAnswers < allAssignments.AssignmentsWithAnswers.Length)
        {
            //Debug.Log("indexForAssignmentsWithAnswers " + indexForAssignmentsWithAnswers);
            allAssignments.assignmentWithAnswers = allAssignments.AssignmentsWithAnswers[index];
            

        }
        if (index == allAssignments.AssignmentsWithAnswers.Length)
        {
            allCardsWithAnswersWereCreated = true;
            allAssignments.assignmentWithAnswers = null;
            //assignments.assignmentWithAnswers = assignments.AssignmentsWithAnswers[assignments.AssignmentsWithAnswers.Length-1];

        }

        //Debug.Log(" randomAssignment.assignmentWithAnswers " + randomAssignment.assignmentWithAnswers);

    }

    void SelectAssignmentWithUserInput_Number(int index)
    {
        if (indexForAssignmentsWithUserInput_Numbers < allAssignments.AssignmentsWithUserInput_Number.Length)
        {
            //Debug.Log("indexForAssignmentsWithUserInput_Numbers " + indexForAssignmentsWithUserInput_Numbers);
            allAssignments.assignmentWithUserInput_Number = allAssignments.AssignmentsWithUserInput_Number[indexForAssignmentsWithUserInput_Numbers];
        

        }
        if (index == allAssignments.AssignmentsWithUserInput_Number.Length)
        {
            allCardsWithUserInput_Numbers_WereCreated = true;
            allAssignments.assignmentWithUserInput_Number = null;
            //assignments.assignmentWithUserInput_Number = assignments.AssignmentsWithUserInput_Number[assignments.AssignmentsWithUserInput_Number.Length -1];
        }

        //Debug.Log("randomAssignment.assignmentWithUserInput_Number " + randomAssignment.assignmentWithUserInput_Number);

    }

    void SelectAssignmentWithUserInput_Text(int index)
    {
        if (indexForAssignmentsWithUserInput_Text < allAssignments.AssignmentsWithUserInput_Text.Length)
        {
            //Debug.Log("indexForAssignmentsWithUserInput_Text " + indexForAssignmentsWithUserInput_Text);
            allAssignments.assignmentWithUserInput_Text = allAssignments.AssignmentsWithUserInput_Text[indexForAssignmentsWithUserInput_Text];
            
        }
        if (index == allAssignments.AssignmentsWithUserInput_Text.Length)
        {
            allCardsWithUserInput_Text_WereCreated = true;
            allAssignments.assignmentWithUserInput_Text = null;
            //assignments.assignmentWithUserInput_Text = assignments.AssignmentsWithUserInput_Text[assignments.AssignmentsWithUserInput_Text.Length -1];
        }

        //Debug.Log("randomAssignment.assignmentWithUserInput_Text " + randomAssignment.assignmentWithUserInput_Text);

    }


    //void CheckTheFirstCard()
    //{
    //    CardController firstCard = GetComponentInChildren<CardController>();
    //    firstCard.Setup(CardGroups[0]);


    //    for (int i = 0; i < createdCards.Length; i++)
    //    {
    //        //createdCards.Contains<>
    //    }
    //}

    void AddAllCreatedCards()
    {
        createdCards = GetComponentsInChildren<CardController>();
    }

    void SelectNextCard()
    {
        indexOfSelectedCard++;

        if (indexOfSelectedCard < reorginizedCards.Length)
        {
            selectedCard.DeactivateCard();
            selectedCard = reorginizedCards[indexOfSelectedCard];
            selectedCard.ActivateCard();
        }

        else if (indexOfSelectedCard == reorginizedCards.Length)
        {
            selectedCard.DeactivateCard();
            wasOpenedAllCards = true;
            RaiseOnFinishedGameEvent();

        }

    }

    void RaiseOnFinishedGameEvent()
    {
        OnFinishedGame?.Invoke();
    }
  
    public void ReorganizeCreatedCards()
    {
        System.Random rnd = new System.Random();
        reorginizedCards = createdCards.OrderBy(x => rnd.Next()).ToArray();
        for (int i = 0; i < reorginizedCards.Length; i++)
        {
            reorginizedCards[i].transform.SetSiblingIndex(i);

        }
    }

}