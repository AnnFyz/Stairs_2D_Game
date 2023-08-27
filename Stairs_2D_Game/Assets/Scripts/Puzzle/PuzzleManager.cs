using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;


public class PuzzleManager : MonoBehaviour
{
    public List<Puzzle_SO> puzzles;
    public static PuzzleManager Instance { get; private set; }
    [SerializeField] List<PuzzleSlot> slotPref;
    [SerializeField] PuzzlePiece piecePref;
    [SerializeField] Transform slotParent, pieceParent;
    public UnityEvent OnCompletedPuzzle;
    int amountOfPlacedPieces = 0;
    int maxAmountOfPlacedPieces;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        maxAmountOfPlacedPieces = slotPref.Count;
        if (OnCompletedPuzzle == null)
        { OnCompletedPuzzle = new UnityEvent(); }

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

    public void AddPlacedPiece()
    {
        if(amountOfPlacedPieces < maxAmountOfPlacedPieces)
        {
            amountOfPlacedPieces++;
        }
        CheckOfAllPiecesArePlaced();
    }

    void CheckOfAllPiecesArePlaced()
    {
      if(amountOfPlacedPieces == maxAmountOfPlacedPieces)
        {
            OnCompletedPuzzle.Invoke();
        }
    }

    public void UpdatePuzzle()
    {

    }
}
