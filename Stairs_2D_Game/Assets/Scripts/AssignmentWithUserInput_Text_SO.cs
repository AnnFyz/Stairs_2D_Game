using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AssignmentWithUserInput_Text", menuName = "Assignments/AssignmentWithUserInput_Text", order = 3)]

public class AssignmentWithUserInput_Text_SO : ScriptableObject
{
    public Assignment currentAssignment;
    public string Question;
    public string RightAnswer;
    public Sprite sprite;

}
