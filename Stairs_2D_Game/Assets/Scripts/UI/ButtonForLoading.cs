using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonForLoading : MonoBehaviour
{
    [SerializeField] int nextSceneIndex;

    public void SetIndexOfNextScene(int index)
    {
        nextSceneIndex = index;
    }

    public void LoadNewScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
       
    }


}
