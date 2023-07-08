using System.Collections;
using System.Collections.Generic;
# if UNITY_EDITOR
using UnityEditor;
# endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField playerNameInput;
    [SerializeField]
    private Text bestScoreText;

    private void Start() {
        if (bestScoreText != null && PersistanceManager.instance != null) {
            bestScoreText.text = $"Best Score: {PersistanceManager.instance.bestScorePlayerName} - {PersistanceManager.instance.bestScore}";
        }
    }

    public void StartGame() {
        PersistanceManager.instance.playerName = playerNameInput.text;

        SceneManager.LoadScene(1);
    }

    public void EndGame() {
        SceneManager.LoadScene(0);
    }

    public void ExitGame() {
        PersistanceManager.instance.SaveGameData();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        # endif
    }
}
