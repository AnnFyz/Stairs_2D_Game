using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultsHandler : MonoBehaviour
{
    public bool isSceneOnlyWithOneGroup = false;
    [SerializeField] GameObject UIPanel;
    [SerializeField] Transform group_TextPref;
    [SerializeField] Transform textObject;

    public static ResultsHandler Instance { get; private set; }
    [SerializeField] int[] amountOfWrongAnswers;
    [SerializeField] int[] amountOfAllAnswers;
    [SerializeField] float[] PercentageOfUnsolvedAssignments;
    [SerializeField] TextMeshProUGUI[] results;
    public int[] sceneIndices;
    public int index;

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
        DeactivateUIPanel();
        CardManager.Instance.OnFinishedGame += HandleResult;
        amountOfWrongAnswers = new int[CardManager.Instance.CardGroups.Length];
        amountOfAllAnswers = new int[CardManager.Instance.CardGroups.Length];
        PercentageOfUnsolvedAssignments = new float[CardManager.Instance.CardGroups.Length];
        results = new TextMeshProUGUI[CardManager.Instance.CardGroups.Length];
        CalculateAmountOfGroupsPref();
        if(CardManager.Instance.CardGroups.Length <= 1)
        {
            isSceneOnlyWithOneGroup = true;
        }
    }

    private void Update()
    {
        for (int i = 0; i < CardManager.Instance.CardGroups.Length; i++)
        {
            textObject.GetChild(i).GetComponent<TextMeshProUGUI>().text = CardManager.Instance.CardGroups[i].Title + ": " + PercentageOfUnsolvedAssignments[i].ToString() + " %";
            results[i] = textObject.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
    }
    public void CalculateAmountOfGroupsPref()
    {
        foreach (var group in CardManager.Instance.CardGroups)
        {
            Transform textObj = Instantiate(group_TextPref);
            textObj.transform.SetParent(textObject.transform);
        }
    }
    public void AddWrongAnswer(int index)
    {
        if(index <= amountOfWrongAnswers.Length)
        {
            amountOfWrongAnswers[index]++;
        }
    }
   
    public void CalculateAmountOfAllAnswers()
    {
        for (int i = 0; i < CardManager.Instance.CardGroups.Length; i++)
        {
            amountOfAllAnswers[i]= CardManager.Instance.CardGroups[i].currentAmountOfCardsOfThisType;
        }
    }
   

    void HandleResult()
    {
        SetupNextSceneIndex();
        CalculatePercentageOfUnsolvedAssignments();
        SetupPanel();
    }
    public void CalculatePercentageOfUnsolvedAssignments()
    {
        for (int i = 0; i < CardManager.Instance.CardGroups.Length; i++)
        {
            PercentageOfUnsolvedAssignments[i] = amountOfWrongAnswers[i] / (amountOfAllAnswers[i] * 0.01f);
        }
    }
    void SetupPanel()
    {
        for (int i = 0; i < CardManager.Instance.CardGroups.Length; i++)
        {
            textObject.GetChild(i).GetComponent<TextMeshProUGUI>().text = CardManager.Instance.CardGroups[i].Title + ": " + PercentageOfUnsolvedAssignments[i].ToString() + " %";
        }

        ActivateUIPanel();
    }

    void ActivateUIPanel()
    {
        UIPanel.SetActive(true);
    }
    public void DeactivateUIPanel()
    {
        UIPanel.SetActive(false);
    }


    void SetupNextSceneIndex()
    {
        if (!isSceneOnlyWithOneGroup)
        {
            for (int i = 0; i < CardManager.Instance.CardGroups.Length; i++)
            {
                textObject.GetChild(i).gameObject.GetComponent<ButtonForLoading>().SetIndexOfNextScene(i + 1);
            }

        }

        else
        {
            for (int i = 0; i < CardManager.Instance.CardGroups.Length; i++)
            {
                textObject.GetChild(i).gameObject.GetComponent<ButtonForLoading>().SetIndexOfNextScene(0);
            }
        }
    }

}
