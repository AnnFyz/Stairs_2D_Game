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
        renderer.color = new Color(1f, 1f, 1f, 0f);
        PuzzleManager.Instance.AddPlacedPiece();
        Debug.Log("AddPlacedPiece");
    }
}
