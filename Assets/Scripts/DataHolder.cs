using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;
    public string playerName;
    public string BestScoreMaker;
    public int BestScore;
    private void Awake()
    {
        //reset_data();
        if (Instance != null)
        {
            Destroy(gameObject);

            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class saveData
    {
        public string BestScoreMaker;
        public int BestScore;
    }
    public void saveScore()
    {
        saveData data = new saveData();
        data.BestScoreMaker = playerName;
        data.BestScore = BestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/BestScore.json", json);

    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/BestScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData data = JsonUtility.FromJson<saveData>(json);

            BestScore = data.BestScore;
            BestScoreMaker = data.BestScoreMaker;
        }
    }
    void reset_data()
    {
        string path = Application.persistentDataPath + "/BestScore.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}

