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
    [SerializeField] List <Transform> slotParents, pieceParents;
    public UnityEvent OnCompletedPuzzle;
    int amountOfPlacedPieces = 0;
    int maxAmountOfPlacedPieces;
    int puzzleIndex = 0;
    [SerializeField] Transform currentPuzzle;
    [SerializeField] List<Transform> startSchemeObjPos;
    [SerializeField] List <Transform> fullSchemeObjPos;
    [SerializeField] List <SpriteRenderer> startSchemes;
    [SerializeField] List <SpriteRenderer> fullSchemes;
    public Action OnFinishedGame;
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
        for (int i = 0; i < puzzles.Count; i++)
        {
            startSchemes[i] = startSchemeObjPos[i].GetComponent<SpriteRenderer>();
            fullSchemes[i] = fullSchemeObjPos[i].GetComponent<SpriteRenderer>();
        }
        
     }       

    private void Start()
    {
        SetupPuzzle();

        if (OnCompletedPuzzle == null)
        { OnCompletedPuzzle = new UnityEvent(); }

        Spawn(puzzleIndex);
    }

    void SetupPuzzle()
    {
        maxAmountOfPlacedPieces = puzzles[puzzleIndex].slotPref.Count;
        startSchemes[puzzleIndex].sprite = puzzles[puzzleIndex].startScheme;
        fullSchemes[puzzleIndex].sprite = null;

    }
    void Spawn(int puzzleIndex)
    {
        //var randomSet = slotPref.OrderBy(s => Random.value).Take(3).ToList();
        List<Transform> piecePositions = new List<Transform>();
        for (int i = 0; i < pieceParents[puzzleIndex].childCount; i++)
        {
            piecePositions.Add(pieceParents[puzzleIndex].GetChild(i));
        }
        var randomPiecePos = piecePositions.OrderBy(s => UnityEngine.Random.value).Take(piecePositions.Count).ToList();

        for (int i = 0; i < puzzles[puzzleIndex].slotPref.Count; i++)
        {
            PuzzleSlot spawnedSlot = Instantiate(puzzles[puzzleIndex].slotPref[i], slotParents[puzzleIndex].GetChild(i).position, Quaternion.identity);
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
        startSchemes[puzzleIndex].sprite = null;
        fullSchemes[puzzleIndex].sprite = null;
        amountOfPlacedPieces = 0;
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
            fullSchemes[puzzleIndex].sprite = puzzles[puzzleIndex].fullScheme;
        }
    }

    public void UpdatePuzzleGame()
    {
        DestroyOldPuzzle();
        puzzleIndex++;
        if (puzzleIndex < puzzles.Count)
        {
            Debug.Log("UpdatePuzzle");

            SetupPuzzle();
            Spawn(puzzleIndex);
        }
        else if(puzzleIndex == puzzles.Count)
        {
           
            Debug.Log("All puzzles are solved");
            RaiseOnFinishedGameEvent();
        }


    }

    public Puzzle_SO GetCurrentPuzzleSO()
    {
        return puzzles[puzzleIndex];
    }

    void RaiseOnFinishedGameEvent()
    {
        OnFinishedGame?.Invoke();
    }
}
