using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Riddle")]

public class Riddle_SO : ScriptableObject
{
    public string description;
    public string[] options;
    public int indexOfTheRightOption;
    public int indexOfTheSecondRightOption;
    public int indexOfTheThirdRightOption;
    public Sprite sprite;
}
