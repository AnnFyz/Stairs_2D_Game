using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Riddle")]

public class Riddle_SO : ScriptableObject
{
    public string option_1;
    public string option_2;
    public string option_3;
    public int indexOfTheRightOption;
    public Sprite sprite;
}
