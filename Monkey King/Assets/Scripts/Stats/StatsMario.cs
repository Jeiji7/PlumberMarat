using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMario : MonoBehaviour
{
    public bool Active = true;
    [Header("TextCanvas")]
    public Text textPoint;
    public Text textBonus;
    public Text textLife;
    public Text textRounds;

    [Header("MarioStats")]
    public static int _healthMario = 3;
    public static int _roundMario = 0;
    public static int MarioBonus = 5000;
    public static int MarioPoints = 0;

    public void RefreshStats() //������ ��� ����� �� ����
    {
        _healthMario = 3;
        _roundMario = 0;
        MarioBonus = 5000 + 1000 * _roundMario;
        MarioPoints = 0;
    }
    public void RefreshBonus() //������ ��� ����� �� ����
    {
        MarioBonus = 5000 + 1000 * _roundMario;
    }
    private void Update()
    {
        textPoint.text = ($"POINT: {MarioPoints}");
        textBonus.text = ($"{MarioBonus}");
        textLife.text = ($"M: {_healthMario}");
        textRounds.text = ($"L: {_roundMario}");
        if (Active == true)
        {
            Active = false;
            StartCoroutine(BonusPoint());
        }
    }
    private IEnumerator BonusPoint()
    {
        yield return new WaitForSeconds(1.66f);
        if (MarioBonus > 0)
        {
            MarioBonus -= 100;
        }
        Active = true;
    }
}
