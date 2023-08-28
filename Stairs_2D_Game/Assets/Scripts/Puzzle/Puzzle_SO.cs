using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Puzzle_SO : ScriptableObject
{
    public string nameOfPuzzle;
    public List<PuzzleSlot> slotPref;
    public Sprite startScheme;
    public Sprite fullScheme;
}
