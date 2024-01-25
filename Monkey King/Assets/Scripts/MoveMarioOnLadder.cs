using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMarioOnLadder : MonoBehaviour
{
    [SerializeField] bool isDownTrigger;
    private bool isPlayerOnLadder = false;
    public Move playerMove;
    //public ExitMarioWithLadder triggerSecond;
    public MiddleTriggerLadder triggerThird;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = true; // ���������� ����, ����� ����� ������ �� ��������.
            playerMove.canHorizontalMove = false;
            print("1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = false; // �������� ����, ����� ����� �������� ��������.
            playerMove.canHorizontalMove = true;
            print("0");
            //triggerSecond.SecondTrigger.SetActive(true);
            triggerThird.ThirdTrigger.SetActive(true);
        }
    }
    void Update()
    {
        if (isPlayerOnLadder)
        {
            if (isDownTrigger)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    //print("ON Ladder");
                    playerMove.onLadder = true;
                }

                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    //print("Out Ladder");
                    playerMove.onLadder = false;
                }
            }
        }
    }

}


