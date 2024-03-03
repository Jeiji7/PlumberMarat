using UnityEngine;

public class ClimbingTheStairs : MonoBehaviour
{
    [SerializeField] bool isDownTrigger;
    public bool isPlayerOnLadder = false;
    public Move playerMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = true;
            isDownTrigger = true;
            print("1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = false;
            playerMove.canHorizontalMove = true;
            print("0");
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
                    playerMove.onLadder = true;
                }
            }
        }
    }
}
