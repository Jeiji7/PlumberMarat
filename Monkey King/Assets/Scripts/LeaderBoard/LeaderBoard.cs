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
        scoreManager = FindObjectOfType<ScoreManager>();
        UpdateListView();
    }

    private void Update()
    {
        UpdateListView();
    }

    public void UpdateListView()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        float[] topScores = scoreManager.topScores;
        int[] topRounds = scoreManager.topRounds;

        for (int i = 0; i < topScores.Length; i++)
        {
            if (topScores[i] > 0)
            {
                CreateListItem(i + 1, topScores[i], topRounds[i]);
            }
        }
    }

    void CreateListItem(int rank, float score, int round)
    {
        GameObject newItem = Instantiate(itemPrefab, contentPanel);

        Text[] texts = newItem.GetComponentsInChildren<Text>();
        texts[0].text = rank.ToString();
        texts[1].text = score.ToString();
        texts[2].text = round.ToString();
    }
}
