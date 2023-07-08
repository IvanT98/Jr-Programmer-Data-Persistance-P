using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager instance;

    public string playerName;
    public string bestScorePlayerName;
    public int bestScore;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);

            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    [System.Serializable]
    private class GameData {
        public string playerName;
        public string bestScorePlayerName;
        public int bestScore;
    }

    public void SaveGameData() {
        GameData data = new() {
            playerName = playerName,
            bestScorePlayerName = bestScorePlayerName,
            bestScore = bestScore
        };
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(GetSaveFilePath(), json);
    }

    public void LoadGameData() {
        string path = GetSaveFilePath();

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            playerName = data.playerName;
            bestScorePlayerName = data.bestScorePlayerName;
            bestScore = data.bestScore;
        }
    }

    private string GetSaveFilePath() {
        return Application.persistentDataPath + "/savefile.json";
    }
}
