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
    [SerializeField] public Riddle_SO[] riddles;
    [SerializeField] Riddle_SO[] reorginizedRiddles;
    public static RiddleController selectedRiddle;
    public RiddleController currentSelectedRiddle;
    public Action OnFinishedGame;
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

    private void Update()
    {
        currentSelectedRiddle = selectedRiddle;
    }
}
