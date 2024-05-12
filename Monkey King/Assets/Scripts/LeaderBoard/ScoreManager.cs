using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float[] topScores = new float[10]; // ������ ��� 10 ������ �����������

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
        // ��������� ������ ���������� �� PlayerPrefs ��� �������
        LoadScoresFromPlayerPrefs();

        // ���������, ���� �� ����� ��������� �� ������� �����
        float currentScore = PlayerPrefs.GetFloat("CurrentScore", 0);
        if (currentScore > 0)
        {
            UpdateTopScores(currentScore);
            PlayerPrefs.DeleteKey("CurrentScore"); // ������� ���� ����� �������������
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
        // �������� ����� ��������� � ������
        int lowestScoreIndex = -1;
        for (int i = 0; i < topScores.Length; i++)
        {
            if (newScore > topScores[i])
            {
                // �������� �������� ������� ����
                for (int j = topScores.Length - 1; j > i; j--)
                {
                    topScores[j] = topScores[j - 1];
                }
                // �������� ����� ���������
                topScores[i] = newScore;
                break;
            }
            else if (topScores[i] == 0 && lowestScoreIndex == -1)
            {
                // ��������� ������ ������� �������� ��������
                lowestScoreIndex = i;
            }
        }

        // ���� ����� ��������� �� ����� � ���-10, �� ���� ��������� �����, �������� ���
        if (lowestScoreIndex != -1 && newScore > 0)
        {
            topScores[lowestScoreIndex] = newScore;
        }

        // ��������� ��������������� ������ � PlayerPrefs
        for (int i = 0; i < topScores.Length; i++)
        {
            PlayerPrefs.SetFloat("TopScore" + i, topScores[i]);
        }
        Debug.Log("opop22");
    }
}
