using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer renderer;
    [SerializeField] Sprite spriteForPiece;
    [SerializeField] string nameForPiece;
    bool wasPlaced = false;

    public Sprite GetSpriteForPiece()
    {
        return spriteForPiece;
    }

    public string GetNameForPiece()
    {
        return nameForPiece;
    }
   public void Placed()
    {
        if (!wasPlaced)
        {
            wasPlaced = true;
            renderer.color = new Color(1f, 1f, 1f, 0f);
            PuzzleManager.Instance.AddPlacedPiece();
            Debug.Log("AddPlacedPiece");
        }
       
    }
}
