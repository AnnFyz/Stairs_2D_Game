using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] string nameOfPiece;
    [SerializeField] TextMeshProUGUI nameOfPieceUI;
    bool isDragging, isPlaced;
    Vector2 offset, originalPos;
    PuzzleSlot slot;
    private void Awake()
    {
        originalPos = transform.position;
    }
    private void Update()
    {
        if (!isDragging ||isPlaced)
        {
            return;
        }

       

        transform.position = GetMousePos() - offset;

    }
    private void OnMouseDown()
    {
        isDragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        if(Vector2.Distance(transform.position, slot.transform.position ) < 45)
        {
            transform.position = slot.transform.position;
            slot.Placed();
            isPlaced = true;
            nameOfPieceUI.text = null;
        }
        else
        {
            transform.position = originalPos;
            isDragging = false;
        }

    }

    Vector2 GetMousePos()
    {
        var mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    public void Init(PuzzleSlot slot)
    {
        
        renderer.sprite = slot.GetSpriteForPiece();
        nameOfPiece = slot.GetNameForPiece();
        nameOfPieceUI.text = nameOfPiece;
        this.slot = slot;
    }
}
