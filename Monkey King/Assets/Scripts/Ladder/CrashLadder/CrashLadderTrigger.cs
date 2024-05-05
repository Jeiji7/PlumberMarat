using UnityEngine;

public class CrashLadder : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    public bool isPlayerOnLadder = false;
    public Move playerMove;
    public GameObject InvisibleWall;

    private void Start()
    {
        InvisibleWall.SetActive(false);
        boxCollider2D = GetComponent<BoxCollider2D>();
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
        if (collision.CompareTag("LadderTrigger") || collision.CompareTag("Player"))
        {
            Exit_Lader.isDown = false;
            isPlayerOnLadder = false;
            playerMove.onLadder = false;
            boxCollider2D.enabled = false;
            boxCollider2D.enabled = true;
            Move.isGrounded = false;
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
                Move.isGrounded = false;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                playerMove.onLadder = true;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
            {
                playerMove.onLadder = false;
            }
        }
    }
}
