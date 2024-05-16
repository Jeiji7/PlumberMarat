using UnityEngine;

public class CrashLaddertriggerUp : MonoBehaviour
{
    public bool isPlayerOnLadder = false;
    public Move playerMove;
    public GameObject flootLadder;
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
            flootLadder.GetComponent<BoxCollider2D>().enabled = true;
            Move.onLadder = false;
            print("0");
            InvisibleWall.SetActive(false);
        }
    }
    void Update()
    {
        if (isPlayerOnLadder && Move.isGrounded)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                playerMove.canHorizontalMove = false;
                Move.onLadder = true;
                flootLadder.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
