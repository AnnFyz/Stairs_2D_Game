using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEditor;
using System;

public class RiddleManager : MonoBehaviour
{
    public static RiddleManager Instance { get; private set; }
    [SerializeField] Transform riddlePrefab;
    [SerializeField] public Riddle_SO[] riddles;
    [SerializeField] RiddleController[] createdRiddles;
    [SerializeField] RiddleController[] reorginizedRiddles;
    public static RiddleController selectedRiddle;
    public RiddleController currentSelectedRiddle;
    public Action OnFinishedGame;
    [SerializeField] int indexOfSelectedRiddle = 0;
    [SerializeField] bool wasOpenedAllRiddles = false;
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
        

    }

    private void Start()
    {
        UI_Assignment_Riddle.Instance.OnAnsweredQuestion += SelectNextRiddle;
        HandleStart();
    }

    public void HandleStart()
    {
        SetupRiddles();
        AddAllCreatedCards();
        ReorganizeCreatedRiddles();
        selectedRiddle = reorginizedRiddles[0];

    }

    private void Update()
    {
        currentSelectedRiddle = selectedRiddle;
    }

    void SetupRiddles()
    {
        for (int i = 0; i < riddles.Length; i++)
        {
            Transform riddle = Instantiate(riddlePrefab, transform);
            riddle.GetComponent<RiddleController>().Setup(riddles[i]);

        }
    }
    void RaiseOnFinishedGameEvent()
    {
        OnFinishedGame?.Invoke();
    }

    void SelectNextRiddle()
    {
        indexOfSelectedRiddle++;

        if (indexOfSelectedRiddle < reorginizedRiddles.Length)
        {
            selectedRiddle.DeactivateRiddle();
            selectedRiddle = reorginizedRiddles[indexOfSelectedRiddle];
            selectedRiddle.ActivateRiddle();
        }

        else if (indexOfSelectedRiddle == reorginizedRiddles.Length)
        {
            selectedRiddle.DeactivateRiddle();
            wasOpenedAllRiddles = true;
            Debug.Log("Over");
            RaiseOnFinishedGameEvent();

        }

    }
    void AddAllCreatedCards()
    {
        createdRiddles = GetComponentsInChildren<RiddleController>();
    }

    public void ReorganizeCreatedRiddles()
    {
        System.Random rnd = new System.Random();
        reorginizedRiddles = createdRiddles.OrderBy(x => rnd.Next()).ToArray();
        for (int i = 0; i < reorginizedRiddles.Length; i++)
        {
            reorginizedRiddles[i].transform.SetSiblingIndex(i);

        }
    }

   
}
