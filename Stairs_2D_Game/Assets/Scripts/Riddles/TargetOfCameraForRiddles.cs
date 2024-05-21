using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOfCameraForRiddles : MonoBehaviour
{
    RectTransform selectedCardRectTransform;
    //void Start()
    //{
    //    selectedCardRectTransform = RiddleManager.selectedRiddle.GetComponent<RectTransform>();
    //    transform.position = selectedCardRectTransform.transform.position;
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        selectedCardRectTransform = RiddleManager.selectedRiddle.GetComponent<RectTransform>();
        transform.position = selectedCardRectTransform.transform.position;
    }
}
