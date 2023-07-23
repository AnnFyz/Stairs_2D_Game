using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    public Transform prefabCard;
    public CardGroup_SO[] CardGroups;
    int AmountOfCardsToInstantiate = 0;
    //public List <CardController> createdCards = new List<CardController>();
    [SerializeField] CardController[] createdCards;
    public static CardController selectedCard;
    public CardController currentselectedCard;
    [SerializeField] int indexOfSelectedCard = 0;
    [SerializeField] bool wasOpenedAllCards = false;
    public CardController[] reorginizedCards;
    public Action OnFinishedGame;

    int groupIndex = 0;
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


    private void Start()
    {
        HandleStart();
    }

    public void HandleStart()
    {
        for (int i = 0; i < CardGroups.Length; i++)
        {
            CardGroups[i].HandleStart();
        }
        CalculateCurrentAmountOfCardsInTheGroup();
        CalculateAmountOfCardsToInstantiate();
        DeleteCards();
        CreateCards();
        AddAllCreatedCards();
        ReorganizeCreatedCards();
        selectedCard = reorginizedCards[0];
        ResultsHandler.Instance.CalculateAmountOfAllAnswers();
    }

    void DeleteCards()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
          Destroy(transform.GetChild(i));
        }
    }
    private void FixedUpdate()
    {
        currentselectedCard = selectedCard;
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

        if (CardGroups.Length > 1)
        {
            foreach (var group in CardGroups)
            {

                for (int i = 0; i < group.currentAmountOfCardsOfThisType; i++)
                {
                    group.GetAssignment();
                    card = CardController.Create(prefabCard, group, transform);
                    card.Setup(group, group.randomAssignment, groupIndex);
                }

                if (groupIndex < CardGroups.Length)
                {
                    groupIndex++;
                }
            }
        }
        else
        {
            for (int i = 0; i < CardGroups[0].currentAmountOfCardsOfThisType; i++)
            {
                CardGroups[0].GetAssignment();
                card = CardController.Create(prefabCard, CardGroups[0], transform);
                card.Setup(CardGroups[0], CardGroups[0].randomAssignment, groupIndex);
            }

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
    CardGroup_SO GetRandomGroup()
    {
        CardGroup_SO group = null;
        var totalWeight = 0;
        foreach (var item in CardGroups)
        {
            totalWeight += (int)Mathf.Round(item.weightCurve.Evaluate(1));
        }
        var rndWeightGroup = UnityEngine.Random.Range(0, totalWeight);
        var processedWeight = 0;
        foreach (var item in CardGroups)
        {
            processedWeight += item.Weight;
            if (rndWeightGroup <= processedWeight)
            {
                group = item;
                break;
            }
        }

        Debug.Log("Group: " + group.name);
        return group;
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