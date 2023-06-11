using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController Create(Transform prefabCard, CardGroup_SO cardGroup, Transform parent)
    {
        Transform cardObj = Instantiate(prefabCard);
        cardObj.transform.parent = parent;
        CardController card = prefabCard.GetComponent<CardController>();
        Debug.Log("Card was created");
        return card;
    }
}
