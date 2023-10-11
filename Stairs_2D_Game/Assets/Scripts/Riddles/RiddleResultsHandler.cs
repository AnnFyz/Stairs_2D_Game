using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class RiddleResultsHandler : MonoBehaviour
{
    public static RiddleResultsHandler Instance { get; private set; }
    [SerializeField] GameObject UIPanel;
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
}
