using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitMarioWithLadder : MonoBehaviour
{
    [SerializeField] bool isUpTrigger;
    private bool isPlayerOnLadder = false;
    public Move playerMove;
    public GameObject flootLadder;
    public GameObject SecondTrigger;
    public MiddleTriggerLadder thirdTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = true;
            playerMove.onLadder = true;
            flootLadder.GetComponent<PolygonCollider2D>().enabled = false;
            print("1");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = false; 
            playerMove.canHorizontalMove = true;
            flootLadder.GetComponent<PolygonCollider2D>().enabled = true;
            playerMove.onLadder = false;
            print("0");
            SecondTrigger.SetActive(false);
            thirdTrigger.ThirdTrigger.SetActive(true);
        }
    }
    void Update()
    {
        if (isPlayerOnLadder)
        {
            if (isUpTrigger)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    playerMove.onLadder = true;
                }
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    playerMove.onLadder = true;
                }
            }
        }
    }
}
