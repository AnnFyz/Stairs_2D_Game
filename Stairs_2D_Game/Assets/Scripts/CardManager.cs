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
    List <CardController> createdCards = new List<CardController>();

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

    private void Start()
    {
        CalculateCurrentAmountOfCardsInTheGroup();
        CalculateAmountOfCardsToInstantiate();
        CreateCards();

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
        foreach (var group in CardGroups)
        {
            for (int i = 0; i < group.currentAmountOfCardsOfThisType; i++)
            {
                group.SelectRandomAssignment();
                CardController card = CardController.Create(prefabCard, group, transform);
                card.Setup(group);
                //Canvas.ForceUpdateCanvases();

                createdCards.Add(card);
            }
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
}