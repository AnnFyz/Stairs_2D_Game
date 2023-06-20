using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    public Transform prefabCard;
    [SerializeField] CardGroup_SO[] CardGroups;
    int AmountOfCardsToInstantiate = 0;
    //public List <CardController> createdCards = new List<CardController>();
    [SerializeField] CardController[] createdCards;
    public static CardController selectedCard;
    [SerializeField] int indexOfSelectedCard = 0;
    [SerializeField] bool wasOpenedAllCards = false;
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
    }


    private void Start()
    {
        CalculateCurrentAmountOfCardsInTheGroup();
        CalculateAmountOfCardsToInstantiate();
        CreateCards();
        AddAllCreatedCards();
        selectedCard = createdCards[0];

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
        foreach (var group in CardGroups)
        {
            for (int i = 0; i < group.currentAmountOfCardsOfThisType; i++)
            {
                group.SetRandomAssignments();

            }
            for (int i = 0; i < group.currentAmountOfCardsOfThisType; i++)
            {
                group.GetRandomAssignment();
                card = CardController.Create(prefabCard, group, transform);
                card.Setup(group, group.randomAssignment);
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

        if (indexOfSelectedCard < createdCards.Length)
        {
            selectedCard.DeactivateCard();
            selectedCard = createdCards[indexOfSelectedCard];
            selectedCard.ActivateCard();
        }

        else if (indexOfSelectedCard == createdCards.Length)
        {
            selectedCard.DeactivateCard();
            wasOpenedAllCards = true;

        }

    }
    void ReorganizePlaceForCards()
    {

    }


    CardGroup_SO GetRandomGroup()
    {
        CardGroup_SO group = null;
        var totalWeight = 0;
        foreach (var item in CardGroups)
        {
            totalWeight += item.Weight;
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

    public void ActivateCard()
    {

    }

    public void DeactivateCard()
    {

    }
}