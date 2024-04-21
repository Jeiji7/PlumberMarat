using System.ComponentModel;
using UnityEngine;

public class Exit_Lader : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    public bool isAscendingUp = false;
    public Move playerMove;
    public bool onLadder = false;
    public GameObject floot;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onLadder = true;
            Debug.Log(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LadderTrigger") || collision.CompareTag("Player"))
        {
            onLadder = false;
            playerMove.onLadder = false;
            floot.GetComponent<PolygonCollider2D>().enabled = true;
            boxCollider2D.enabled = false;
            boxCollider2D.enabled = true;
            Debug.Log(2);
        }
    }
    void Update()
    {
        if (onLadder && Move.isGrounded)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                floot.GetComponent<PolygonCollider2D>().enabled = false;
                playerMove.onLadder = true;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                floot.GetComponent<PolygonCollider2D>().enabled = false;
                playerMove.onLadder = true;
            }
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
            {
                floot.GetComponent<PolygonCollider2D>().enabled = true;
                playerMove.onLadder = false;
            }
        }
        //if (isAscendingUp)
        //{
        //    playerMove.onLadder = false;
        //}
    }
}
