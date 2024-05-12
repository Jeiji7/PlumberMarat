using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public GameObject itemPrefab; // Префаб элемента списка
    public Transform contentPanel; // Панель, содержащая элементы
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        UpdateListView();
    }

    private void Update()
    {
        scoreManager = GetComponent<ScoreManager>();
        UpdateListView();
    }

    public void UpdateListView()
    {
        // Очистить старые элементы списка
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // Получить лучшие результаты из ScoreManager
        float[] topScores = scoreManager.topScores;

        // Создать новые элементы списка для лучших результатов
        for (int i = 0; i < topScores.Length; i++)
        {
            if (topScores[i] > 0)
            {
                CreateListItem(i + 1, topScores[i]);
            }
        }
    }
    void CreateListItem(int rank, float score)
    {
        // Создать новый элемент списка
        GameObject newItem = Instantiate(itemPrefab, contentPanel);

        // Установить текст элемента
        Text[] texts = newItem.GetComponentsInChildren<Text>();
        texts[0].text = rank.ToString(); // Номер результата
        texts[1].text = score.ToString(); // Количество очков
    }
}
