using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int HighScore;
    public string HighScoreName;
    public string UserName;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    public class SaveData
    {
        public int HighScore;
        public string HighScoreName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.HighScoreName = HighScoreName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScore = data.HighScore;
            HighScoreName = data.HighScoreName;
        }
    }
}
