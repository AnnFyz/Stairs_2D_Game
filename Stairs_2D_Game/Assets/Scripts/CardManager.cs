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
        CreateCards();

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
    void CreateCards()
    {
        CardController card;

        if (CardGroups.Length > 0)
        {
            

            foreach (var group in CardGroups)
            {
                Debug.Log("group " + group);
                AddAllAssignments(group);

                for (int i = 0; i < group.currentAmountOfCardsOfThisType; i++)
                {
                    //Debug.Log("group " + group.currentAmountOfCardsOfThisType);
                    //group.GetAssignment();
                    card = CardController.Create(prefabCard, transform);
                    card.Setup(group);
                   

                }

                if (groupIndex < CardGroups.Length)
                {
                    groupIndex++;
                }
            }
        }

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
    void CheckTheFirstCard()
    {
        CardController firstCard = GetComponentInChildren<CardController>();
        firstCard.Setup(CardGroups[0]);


        for (int i = 0; i < createdCards.Length; i++)
        {
            //createdCards.Contains<>
        }
    }

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