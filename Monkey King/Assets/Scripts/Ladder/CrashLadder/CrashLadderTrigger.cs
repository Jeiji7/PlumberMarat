using UnityEngine;

public class CrashLadder : MonoBehaviour
{
    public bool isPlayerOnLadder = false;
    public Move playerMove;
    public GameObject InvisibleWall;

    void Start()
    {
        InvisibleWall.SetActive(false);
    }
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
            InvisibleWall.SetActive(false);
        }
    }
    void Update()
    {
        if (isPlayerOnLadder && Move.isGrounded)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                playerMove.onLadder = true;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                playerMove.onLadder = false;
            }
        }
    }
}
