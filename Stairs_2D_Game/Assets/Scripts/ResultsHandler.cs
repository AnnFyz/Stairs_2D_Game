using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultsHandler : MonoBehaviour
{
    [SerializeField] GameObject UIPanel;
    [SerializeField] Transform group_TextPref;
    [SerializeField] Transform textObject;

    public static ResultsHandler Instance { get; private set; }
    [SerializeField] int[] amountOfWrongAnswers;
    [SerializeField] int[] amountOfAllAnswers;
    [SerializeField] float[] PercentageOfUnsolvedAssignments;



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
        CalculateAmountOfGroupsPref();
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
        // textObject.GetChild(index).GetComponent<TextMeshProUGUI>().text =
        amountOfWrongAnswers[index]++;
    }
    //public void AddWrongAnswer(Assignment typeOfAssignment)
    //{
    //    if (typeOfAssignment == Assignment.Assignment_With_Answer_Options)
    //    {
    //        amountOfWrongAnswers_AssignmentsWithAnswers++;
    //    }
    //    if (typeOfAssignment == Assignment.Assignment_With_Number_Input)
    //    {
    //        amountOfWrongAnswers_AssignmentsUserInput_Numbers++;
    //    }
    //    if (typeOfAssignment == Assignment.Assignment_With_Text_Input)
    //    {
    //        amountOfWrongAnswers_AssignmentsUserInput_Text++;
    //    }
    //}
    public void CalculateAmountOfAllAnswers()
    {
        for (int i = 0; i < CardManager.Instance.CardGroups.Length; i++)
        {
            amountOfAllAnswers[i]= CardManager.Instance.CardGroups[i].currentAmountOfCardsOfThisType;
        }
    }
    //public void CalculateAmountOfAllAnswers()
    //{
    //    for (int i = 0; i < CardManager.Instance.reorginizedCards.Length; i++)
    //    {
    //        if (CardManager.Instance.reorginizedCards[i].assignmentType == Assignment.Assignment_With_Answer_Options)
    //        {
    //            amountOfAllAnswers_AssignmentsWithAnswers++;
    //        }
    //        if (CardManager.Instance.reorginizedCards[i].assignmentType == Assignment.Assignment_With_Number_Input)
    //        {
    //            amountOfAllgAnswers_AssignmentsUserInput_Numbers++;
    //        }
    //        if (CardManager.Instance.reorginizedCards[i].assignmentType == Assignment.Assignment_With_Text_Input)
    //        {
    //            amountOfAllAnswers_AssignmentsUserInput_Text++;
    //        }
    //    }
    //}

    void HandleResult()
    {
        CalculatePercentageOfUnsolvedAssignments();
        SetupPanel();
    }
    public void CalculatePercentageOfUnsolvedAssignments()
    {
        for (int i = 0; i < CardManager.Instance.CardGroups.Length; i++)
        {
            PercentageOfUnsolvedAssignments[i] = amountOfWrongAnswers[i] / (amountOfAllAnswers[i] * 0.01f);
        }
        //PercentageOfInsolvedAssignmentsWithAnswers = amountOfWrongAnswers_AssignmentsWithAnswers * (amountOfAllAnswers_AssignmentsWithAnswers * 0.01f);
        //PercentageOfInsolvedAssignmentsWithUserInput_Numbers = amountOfWrongAnswers_AssignmentsUserInput_Numbers * (amountOfAllgAnswers_AssignmentsUserInput_Numbers * 0.01f);
        //PercentageOfInsolvedAssignmentsWithUserInput_Text = amountOfWrongAnswers_AssignmentsUserInput_Text * (amountOfAllAnswers_AssignmentsUserInput_Text * 0.01f);
    }
    void SetupPanel()
    {
        for (int i = 0; i < CardManager.Instance.CardGroups.Length; i++)
        {
            textObject.GetChild(i).GetComponent<TextMeshProUGUI>().text = PercentageOfUnsolvedAssignments[i].ToString();
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

}
