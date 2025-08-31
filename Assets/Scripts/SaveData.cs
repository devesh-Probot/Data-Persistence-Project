using UnityEngine;
using System.IO;

[System.Serializable]

public class GameSaver
{
    public string playerName;
    public int bestScore;
}

public class SaveData : MonoBehaviour
{
    public MenuManager menuManagerScript;

    void Awake()
    {
        LoadGame();
    }

    public void SaveGameData()
    {
        GameSaver data = new GameSaver();
        data.playerName = MenuManager.Instance.playerName;
        data.bestScore = MenuManager.Instance.bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        string path  = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameSaver data = JsonUtility.FromJson<GameSaver>(json);
            menuManagerScript.playerName = data.playerName;
            menuManagerScript.bestScore = data.bestScore;
            Debug.Log("Game Loaded");
        }
    }
}