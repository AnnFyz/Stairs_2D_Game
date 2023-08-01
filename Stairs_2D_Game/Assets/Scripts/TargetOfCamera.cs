using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOfCamera : MonoBehaviour
{
    RectTransform selectedCardRectTransform;
    void Start()
    {
        selectedCardRectTransform = CardManager.selectedCard.GetComponent<RectTransform>();
        transform.position = selectedCardRectTransform.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        selectedCardRectTransform = CardManager.selectedCard.GetComponent<RectTransform>();
        transform.position = selectedCardRectTransform.transform.position;
    }
}
