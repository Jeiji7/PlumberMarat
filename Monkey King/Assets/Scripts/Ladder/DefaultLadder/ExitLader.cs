using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Exit_Lader : MonoBehaviour
{
    public Animator MarioAnimation;
    private BoxCollider2D boxCollider2D;
    public static bool isDown = false;
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
            isDown = true;
        }

    }

        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LadderTrigger") || collision.CompareTag("Player"))
        {
            isDown = false;
            onLadder = false;
            playerMove.onLadder = false;
            floot.GetComponent<BoxCollider2D>().enabled = true;
            boxCollider2D.enabled = false;
            boxCollider2D.enabled = true;
            Move.isGrounded = false;
            Debug.Log(2);
        }
    }
    void Update()
    {
        if (onLadder && Move.isGrounded)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                MarioAnimation.SetBool("isLadderAnim", false);
                MarioAnimation.SetFloat("isClimbAnim", 1);
                floot.GetComponent<BoxCollider2D>().enabled = false;
                playerMove.onLadder = true;
                Move.isGrounded = false;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                MarioAnimation.SetBool("isLadderAnim", false);
                MarioAnimation.SetFloat("isClimbAnim", -1);
                floot.GetComponent<BoxCollider2D>().enabled = false;
                playerMove.onLadder = true;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
            {
                floot.GetComponent<BoxCollider2D>().enabled = true;
                playerMove.onLadder = false;
            }
        }
    }
}
