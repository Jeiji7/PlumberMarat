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
            MarioAnimation.SetFloat("isClimbAnim", 1);
            onLadder = true;
            isDown = true;
        }

    }

        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LadderTrigger") || collision.CompareTag("Player"))
        {
            MarioAnimation.SetFloat("isClimbAnim", 0);
            isDown = false;
            onLadder = false;
            Move.onLadder = false;
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
            Bounds colliderBounds = boxCollider2D.bounds;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                // Рассчитываем центр коллайдера
                Vector3 triggerCenter = new Vector3(colliderBounds.center.x, Move.tr.position.y, Move.tr.position.z);
                // Устанавливаем позицию персонажа в центр триггера
                Move.tr.position = triggerCenter;
                MarioAnimation.SetBool("isLadderAnim", true);
                MarioAnimation.SetFloat("isClimbAnim", 1);
                floot.GetComponent<BoxCollider2D>().enabled = false;
                Move.onLadder = true;
                Move.isGrounded = false;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 triggerCenter = new Vector3(colliderBounds.center.x, Move.tr.position.y, Move.tr.position.z);

                // Устанавливаем позицию персонажа в центр триггера
                Move.tr.position = triggerCenter;
                MarioAnimation.SetBool("isLadderAnim", true);
                MarioAnimation.SetFloat("isClimbAnim", 1);
                floot.GetComponent<BoxCollider2D>().enabled = false;
                Move.onLadder = true;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
            {
                floot.GetComponent<BoxCollider2D>().enabled = true;
                Move.onLadder = false;
            }
        }
    }
}
