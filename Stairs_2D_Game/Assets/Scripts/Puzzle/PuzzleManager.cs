using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] List<PuzzleSlot> slotPref;
    [SerializeField] PuzzlePiece piecePref;
    [SerializeField] Transform slotParent, pieceParent;

    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        var randomSet = slotPref.OrderBy(s => Random.value).Take(3).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            PuzzleSlot spawnedSlot = Instantiate(randomSet[i], slotParent.GetChild(i).position, Quaternion.identity);

            PuzzlePiece spawnedPiece = Instantiate(piecePref, pieceParent.GetChild(i).position, Quaternion.identity);

            spawnedPiece.Init(spawnedSlot);
        }
    }
}
