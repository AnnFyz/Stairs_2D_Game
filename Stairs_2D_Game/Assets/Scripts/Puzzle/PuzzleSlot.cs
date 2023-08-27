using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer renderer;
    [SerializeField] Sprite spriteForPiece;

    public Sprite GetSpriteForPiece()
    {
        return spriteForPiece;
    }
   public void Placed()
    {

    }
}
