using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
public class SaveLoadManager : MonoBehaviour
{
    public event UnityAction e_EndLoadFile;
    private GameData gameData;
    public GameData GameData => gameData;

    void Awake()
    {
        // загрузка данных игры из JSON файла при старте игры
        LoadGameData();
    }

    private void Start()
    {
        print(Application.persistentDataPath);
    }
    public void SaveGameData()
    {
        // сохранение данных игры в JSON файл
        string filePath = Application.persistentDataPath + "/game_data.json";
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, jsonData);
    }
    public void SaveInitButton(int index)
    {
        gameData.indexButton = index;
        // сохранение данных игры в JSON файл
        string filePath = Application.persistentDataPath + "/game_data.json";
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, jsonData);
    }
    public void OpenNextLvl(int currentLvl)
    {
        int nextLvl = currentLvl+1;
        var lenght = gameData.levels.Length;
        if (nextLvl < lenght)
        {
            gameData.levels[nextLvl].IsOpen = true;
            SaveGameData();
        }
    }
    public void LoadGameData()
    {
        // загрузка данных игры из JSON файла
        string filePath = Application.persistentDataPath + "/game_data.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(jsonData);
        }
        else
        {
            // создание новых данных игры, если JSON файл еще не существует
            gameData = new GameData();
            gameData.volume = 0.5f;
            //  gameData.language = "english";
            gameData.levels = new LevelData[10]; // создание трех уровней
            for (int i = 0; i < 10; i++)
            {
                gameData.levels[i] = new LevelData();
                gameData.levels[i].IsOpen = false;
                // gameData.levels[i].Time = 0f;
                // gameData.levels[i].Score = 0;
            }
            gameData.levels[0].IsOpen = true;
            SaveGameData(); // сохранение новых данных игры в JSON файл
        }
        e_EndLoadFile?.Invoke();
    }
}
