using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float[] topScores = new float[10]; // Массив для 10 лучших результатов
    public int[] topRounds = new int[10]; // Массив для количества раундов
    private GameDataManager gameDataManager;

    private void Start()
    {
        gameDataManager = FindObjectOfType<GameDataManager>();
        LoadScoresFromDataManager();
    }

    private void LoadScoresFromDataManager()
    {
        for (int i = 0; i < topScores.Length; i++)
        {
            topScores[i] = gameDataManager.LoadScore(i);
            topRounds[i] = gameDataManager.LoadRound(i);
        }
    }

    public void UpdateTopScores(float newScore, int newRound)
    {
        gameDataManager.SaveData(newScore, newRound);

        // Добавить новый результат в массив
        int lowestScoreIndex = -1;
        for (int i = 0; i < topScores.Length; i++)
        {
            if (newScore > topScores[i])
            {
                // Сдвинуть элементы массива вниз
                for (int j = topScores.Length - 1; j > i; j--)
                {
                    topScores[j] = topScores[j - 1];
                    topRounds[j] = topRounds[j - 1];
                }
                // Вставить новый результат
                topScores[i] = newScore;
                topRounds[i] = newRound;
                break;
            }
            else if (topScores[i] == 0 && lowestScoreIndex == -1)
            {
                // Запомнить индекс первого нулевого элемента
                lowestScoreIndex = i;
            }
        }
    }
}
