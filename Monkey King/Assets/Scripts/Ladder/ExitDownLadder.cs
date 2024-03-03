using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool isPlayerOnLadder;
    public Move playerMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnLadder = false;
            playerMove.canHorizontalMove = true;
            print("1");
        }
    }

    void Update()
    {
        if (isPlayerOnLadder)
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
