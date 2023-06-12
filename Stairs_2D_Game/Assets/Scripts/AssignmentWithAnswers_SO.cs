using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [CreateAssetMenu(fileName = "AssignmentWithAnswers", menuName = "Assignments/AssignmentWithAnswers", order = 1)]
    public class AssignmentWithAnswers_SO : ScriptableObject
    {
        public Assignment currentAssignment;
        public string Question;
        public string[] Answers;
        public int IndexOfRightAnswer;
    }


    


