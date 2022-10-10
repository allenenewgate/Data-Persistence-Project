using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public static string playerName;
    public static string highScoreName;
    public static int highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        ReadSaveFile();
    }

    public static void SaveToFile()
    {
        SaveData data = new SaveData();
        string saveFile = Application.persistentDataPath + "/savefile.json";
        data.name = highScoreName;
        data.score = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFile, json);
    }

    void ReadSaveFile()
    {
        string saveFile = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(saveFile))
        {
            string json = File.ReadAllText(saveFile);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.score;
            highScoreName = data.name;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

}
