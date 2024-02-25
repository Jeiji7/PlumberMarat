using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleTriggerLadder : MonoBehaviour
{
    [SerializeField] bool isUpTrigger;
    public bool isPlayerOnLadder = false;
    public Move playerMove;
    public GameObject flootLadder;
    public GameObject ThirdTrigger;

    void Start()
    {
        ThirdTrigger.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = true;
            print("1");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = false;
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
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    playerMove.canHorizontalMove = false;
                    playerMove.onLadder = true;
                    flootLadder.GetComponent<PolygonCollider2D>().enabled = false;
                }
            }
        }
    }
}
