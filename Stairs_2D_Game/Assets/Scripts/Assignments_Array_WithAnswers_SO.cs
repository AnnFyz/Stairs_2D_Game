using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assignments_Array_WithAnswers", menuName = "Assignment_Arrays/AssignmentsWithAnswers", order = 1)]

public class Assignments_Array_WithAnswers_SO : ScriptableObject
{
    public AssignmentWithAnswers_SO[] assignments;
}
