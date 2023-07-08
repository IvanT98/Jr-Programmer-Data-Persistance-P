using System.Collections;
using System.Collections.Generic;
# if UNITY_EDITOR
using UnityEditor;
# endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void EndGame() {
        SceneManager.LoadScene(0);
    }

    public void ExitGame() {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        # endif
    }
}
