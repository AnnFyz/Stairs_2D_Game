using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    public Transform prefabCard;
    [SerializeField] CardGroup_SO[] CardGroups;
    int AmountOfCardsToInstantiate = 0;

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
        CalculateAmountOfCardsToInstantiate();
        CreateCardsAndDistributeGroups();
    }
    void CalculateAmountOfCardsToInstantiate()
    {
        foreach (var group in CardGroups)
        {
            AmountOfCardsToInstantiate += group.currentAmountOfCardsOfThisType;
        }
    }

    void CreateCardsAndDistributeGroups()
    {
        for (int i = 0; i < AmountOfCardsToInstantiate; i++)
        {
            CardController card = CardController.Create(prefabCard, CardGroups[Random.Range(0, CardGroups.Length)], transform);
            

        }
    }
}