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
    //[SerializeField] List<PuzzleSlot> slotPref;
    [SerializeField] PuzzlePiece piecePref;
    [SerializeField] Transform slotParent, pieceParent;
    public UnityEvent OnCompletedPuzzle;
    int amountOfPlacedPieces = 0;
    int maxAmountOfPlacedPieces;
    int puzzleIndex = 0;
    [SerializeField] Transform currentPuzzle;
    [SerializeField] Transform startSchemeObj;
    [SerializeField] Transform fullSchemeObj;
    [SerializeField] SpriteRenderer startScheme;
    [SerializeField] SpriteRenderer fullScheme;
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
        startScheme = startSchemeObj.GetComponent<SpriteRenderer>();
        fullScheme = fullSchemeObj.GetComponent<SpriteRenderer>();
     }       

    private void Start()
    {
        maxAmountOfPlacedPieces = puzzles[puzzleIndex].slotPref.Count;
        startScheme.sprite = puzzles[puzzleIndex].startScheme;
        fullScheme.sprite = null;

        if (OnCompletedPuzzle == null)
        { OnCompletedPuzzle = new UnityEvent(); }

        Spawn(puzzleIndex);
    }
    void Spawn(int puzzleIndex)
    {
        //var randomSet = slotPref.OrderBy(s => Random.value).Take(3).ToList();
        List<Transform> piecePositions = new List<Transform>();
        for (int i = 0; i < pieceParent.childCount; i++)
        {
            piecePositions.Add(pieceParent.GetChild(i));
        }
        var randomPiecePos = piecePositions.OrderBy(s => UnityEngine.Random.value).Take(piecePositions.Count).ToList();

        for (int i = 0; i < puzzles[puzzleIndex].slotPref.Count; i++)
        {
            PuzzleSlot spawnedSlot = Instantiate(puzzles[puzzleIndex].slotPref[i], slotParent.GetChild(i).position, Quaternion.identity);
            spawnedSlot.transform.SetParent(currentPuzzle);

            PuzzlePiece spawnedPiece = Instantiate(piecePref, randomPiecePos[i].position, Quaternion.identity);
            spawnedPiece.transform.SetParent(currentPuzzle);

            spawnedPiece.Init(spawnedSlot); // to assign the right sprite for the certain slot
        }
    }

    void DestroyOldPuzzle()
    {
        for (int i = 0; i < currentPuzzle.childCount; i++)
        {
            GameObject partOfPuzzle = currentPuzzle.GetChild(i).gameObject;
            Destroy(partOfPuzzle);
        }
        startScheme.sprite = null;
        fullScheme.sprite = null;

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
            fullScheme.sprite = puzzles[puzzleIndex].fullScheme;
        }
    }

    public void UpdatePuzzleGame()
    {
        if(puzzleIndex < puzzles.Count)
        {
            DestroyOldPuzzle();
            puzzleIndex++;
            Debug.Log("UpdatePuzzle");

            //maxAmountOfPlacedPieces = puzzles[puzzleIndex].slotPref.Count;
            //Spawn(puzzleIndex);
        }
        else if(puzzleIndex == puzzles.Count)
        {
            Debug.Log("All puzzles are solved");
        }


    }
}
