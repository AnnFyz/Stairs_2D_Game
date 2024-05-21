using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class ButtonForLoading : MonoBehaviour
{
    [SerializeField] int nextSceneIndex;
    [SerializeField] UnityEvent OnLoadedScene;

    public void SetIndexOfNextScene(int index)
    {
        nextSceneIndex = index;
    }

    public void LoadNewScene()
    {
        OnLoadedScene?.Invoke();
        SceneManager.LoadScene(nextSceneIndex);
    }


}
