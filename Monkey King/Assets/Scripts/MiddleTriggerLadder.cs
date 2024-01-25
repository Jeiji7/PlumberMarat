using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleTriggerLadder : MonoBehaviour
{
    [SerializeField] bool isUpTrigger;
    private bool isPlayerOnLadder = false;
    public Move playerMove;
    public GameObject flootLadder;
    public GameObject ThirdTrigger;
    //public ExitMarioWithLadder triggerSecond;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                isPlayerOnLadder = true;
                //playerMove.canHorizontalMove = true;
                print("1");
                //triggerSecond.SecondTrigger.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = false;
            //ThirdTrigger.SetActive(false);
            //playerMove.canHorizontalMove = true;
            flootLadder.GetComponent<PolygonCollider2D>().enabled = true;
            playerMove.onLadder = false;
            print("0");
            
        }
    }
    void Update()
    {
        if (isPlayerOnLadder)
        {
            if (isUpTrigger)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    playerMove.onLadder = false;
                    flootLadder.GetComponent<PolygonCollider2D>().enabled = true;
                }

                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    playerMove.onLadder = true;
                    flootLadder.GetComponent<PolygonCollider2D>().enabled = false;
                }
            }
        }
    }
}
