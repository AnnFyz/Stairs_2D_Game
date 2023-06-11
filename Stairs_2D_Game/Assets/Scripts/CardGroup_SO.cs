using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Assignment
{
    Assignment_With_Answer_Options,
    Assignment_With_Number_Input
}
[CreateAssetMenu]
public class CardGroup_SO : ScriptableObject
{
    [SerializeField] string Title;
    public int numberOfAssignmentGroup;
    [Range(0, 100)]
    public int Weight = 0;
    public Color groupColor;
    public Assignment currentTypeOfAssignment;
    public int currentAmountOfCardsOfThisType;
}
