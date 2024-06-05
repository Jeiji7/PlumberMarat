using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    private string saveDir = "C:/GameSave";
    private string saveFile = "C:/GameSave/scores.txt";

    void Start()
    {
        InitGameData();
    }

    private void InitGameData()
    {
        if (!Directory.Exists(saveDir))
        {
            Directory.CreateDirectory(saveDir);
        }

        if (!File.Exists(saveFile))
        {
            File.WriteAllText(saveFile, "0");
        }
    }

    public void SaveData(float score, int round)
    {
        string data = score + ";" + round + "\n"; // Добавляем символ новой строки для разделения записей
        File.AppendAllText(saveFile, data); // Добавляем данные в конец файла
    }

    public float LoadScore(int index)
    {
        if (File.Exists(saveFile))
        {
            string data = File.ReadAllText(saveFile);
            string[] parts = data.Split(';');

            if (index < parts.Length && float.TryParse(parts[index], out float score))
            {
                return score;
            }
        }

        return 0;
    }

    public int LoadRound(int index)
    {
        if (File.Exists(saveFile))
        {
            string data = File.ReadAllText(saveFile);
            string[] parts = data.Split(';');

            if (index > parts.Length - 1 && int.TryParse(parts[index], out int round))
            {
                return round;
            }
        }

        return 0;
    }
}
