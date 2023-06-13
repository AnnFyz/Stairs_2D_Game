using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Assignment_With_Answers : MonoBehaviour
{
    public static UI_Assignment_With_Answers Instance { get; private set; }
    [SerializeField] GameObject UIPanel;
    [SerializeField] GameObject question; // for TextMeshPro
    [SerializeField] GameObject answer_1;
    [SerializeField] GameObject answer_2;
    [SerializeField] GameObject answer_3;
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
        UIPanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIPanel.SetActive(false);
        }
    }
    public void ActivateUIPanel(string question, string answer_1, string answer_2, string answer_3)
    {
        UIPanel.SetActive(true);
        SetupPanel(question, answer_1, answer_2, answer_3);
    }
    void SetupPanel(string question, string answer_1, string answer_2, string answer_3)
    {
        this.question.GetComponent<TextMeshProUGUI>().text = question;
        this.answer_1.GetComponentInChildren<TextMeshProUGUI>().text = answer_1;
        this.answer_2.GetComponentInChildren<TextMeshProUGUI>().text = answer_2;
        this.answer_3.GetComponentInChildren<TextMeshProUGUI>().text = answer_3;
    }

   public void SelectAnswer()
    {
        UIPanel.SetActive(false);
    }
}
