using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMario : MonoBehaviour
{
    [Header("TextCanvas")]
    public Text textPoint;
    public Text textBonus;
    public Text textLife;
    public Text textRounds;

    [Header("MarioStats")]
    public static int _healthMario = 3;
    public static int _roundMario = 0;
    public static int MarioBonus = 6000;
    public static int MarioPoints = 0; 

    public void RefreshStats() //Смерть или вышел из игры
    {
        _healthMario = 3;
        _roundMario = 0;
        MarioBonus = 6000;
        MarioPoints = 0;
    }
    public void RefreshBonus() //Смерть или вышел из игры
    {
        MarioBonus = 6000;
    }
    private void Update()
    {
        textPoint.text = ($"POINT: {MarioPoints}");
        textBonus.text = ($"{MarioBonus}");
        textLife.text = ($"M: {_healthMario}");
        textRounds.text = ($"L: {_roundMario}");
    }
   
}
