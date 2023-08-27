using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] List<PuzzleSlot> slotPref;
    [SerializeField] PuzzlePiece piecePref;
    [SerializeField] Transform slotParent, pieceParent;
    Action OnCompletedPuzzle;

    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        //var randomSet = slotPref.OrderBy(s => Random.value).Take(3).ToList();
        List<Transform> piecePositions = new List<Transform>();
        for (int i = 0; i < pieceParent.childCount; i++)
        {
            piecePositions.Add(pieceParent.GetChild(i));
        }
        var randomPiecePos = piecePositions.OrderBy(s => UnityEngine.Random.value).Take(piecePositions.Count).ToList();

        for (int i = 0; i < slotPref.Count; i++)
        {
            PuzzleSlot spawnedSlot = Instantiate(slotPref[i], slotParent.GetChild(i).position, Quaternion.identity);

            PuzzlePiece spawnedPiece = Instantiate(piecePref, randomPiecePos[i].position, Quaternion.identity);

            spawnedPiece.Init(spawnedSlot); // to assign the right sprite for the certain slot
        }
    }
}
