using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public static CardController Create(Transform prefabCard, CardGroup_SO cardGroup, Transform parent)
    {
        Transform cardObj = Instantiate(prefabCard);
        cardObj.transform.SetParent(parent);
        cardObj.GetComponentInChildren<Image>().color = cardGroup.groupColor;
        CardController card = prefabCard.GetComponent<CardController>();
        Debug.Log("Card was created");
        Canvas.ForceUpdateCanvases();
        return card;
    }


}
