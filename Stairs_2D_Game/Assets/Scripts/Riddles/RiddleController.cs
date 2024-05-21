using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddleController : MonoBehaviour
{
    public bool isRiddleActivated = false;
    public Riddle_SO riddle;
    private void Start()
    {
        if (this != RiddleManager.selectedRiddle)
        {
            gameObject.GetComponent<Button>().interactable = false;
            isRiddleActivated = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            isRiddleActivated = true;
        }
    }

    public void Setup(Riddle_SO riddle)
    {
        this.riddle = riddle;
    }

    public void ActivateUIPanel()
    {
        if (this == RiddleManager.selectedRiddle)
        {
            UI_Assignment_Riddle.Instance.ActivateUIPanel(riddle.description, riddle.options[0], riddle.options[1], riddle.options[2], riddle.sprite);
        }
    }
    public void ActivateRiddle()
    {
        if (this == RiddleManager.selectedRiddle)
        {
            gameObject.GetComponent<Button>().interactable = true;
            isRiddleActivated = true;
        }
    }

    public void DeactivateRiddle()
    {

        gameObject.GetComponent<Button>().interactable = false;
        isRiddleActivated = false;

    }

    public void DestroyRiddle()
    {

        Destroy(gameObject);

    }
}
