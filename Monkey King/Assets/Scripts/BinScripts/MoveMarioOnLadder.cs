using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMarioOnLadder : MonoBehaviour
{
    [SerializeField] bool isDownTrigger;
    public bool isPlayerOnLadder = false;
    public Move playerMove;
    public GameObject InvisibleWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = true; 
            print("1");
            InvisibleWall.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = false; 
            playerMove.canHorizontalMove = true;
            print("0");
            //InvisibleWall.SetActive(false);
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
                    Move.onLadder = true;
                }

                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    //print("Out Ladder");
                    Move.onLadder = false;
                }
            }
        }
    }

}


