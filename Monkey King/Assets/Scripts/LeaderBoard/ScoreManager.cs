using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float[] topScores = new float[10]; // Массив для 10 лучших результатов

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
        // Загрузить лучшие результаты из PlayerPrefs при запуске
        LoadScoresFromPlayerPrefs();

        // Проверить, есть ли новый результат из игровой сцены
        float currentScore = PlayerPrefs.GetFloat("CurrentScore", 0);
        if (currentScore > 0)
        {
            UpdateTopScores(currentScore);
            PlayerPrefs.DeleteKey("CurrentScore"); // Удалить ключ после использования
        }
    }

    private void LoadScoresFromPlayerPrefs()
    {
        for (int i = 0; i < topScores.Length; i++)
        {
            topScores[i] = PlayerPrefs.GetFloat("TopScore" + i, 0);
        }
        Debug.Log("opop");
    }

    private void UpdateTopScores(float newScore)
    {
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
                }
                // Вставить новый результат
                topScores[i] = newScore;
                break;
            }
            else if (topScores[i] == 0 && lowestScoreIndex == -1)
            {
                // Запомнить индекс первого нулевого элемента
                lowestScoreIndex = i;
            }
        }

        // Если новый результат не попал в топ-10, но есть свободные места, добавить его
        if (lowestScoreIndex != -1 && newScore > 0)
        {
            topScores[lowestScoreIndex] = newScore;
        }

        // Сохранить отсортированный массив в PlayerPrefs
        for (int i = 0; i < topScores.Length; i++)
        {
            PlayerPrefs.SetFloat("TopScore" + i, topScores[i]);
        }
        Debug.Log("opop22");
    }
}
