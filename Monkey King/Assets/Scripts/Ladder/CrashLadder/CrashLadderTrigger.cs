using UnityEngine;

public class CrashLadder : MonoBehaviour
{
    public Animator MarioAnimation;
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
            MarioAnimation.SetFloat("isClimbAnim", 1);
            isPlayerOnLadder = true;
            print("1");
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LadderTrigger") || collision.CompareTag("Player"))
        {
            MarioAnimation.SetFloat("isClimbAnim", 0);
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
            Bounds colliderBounds = boxCollider2D.bounds;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                // Рассчитываем центр коллайдера
                Vector3 triggerCenter = new Vector3(colliderBounds.center.x, Move.tr.position.y, Move.tr.position.z);
                // Устанавливаем позицию персонажа в центр триггера
                Move.tr.position = triggerCenter;
                MarioAnimation.SetBool("isLadderAnim", true);
                MarioAnimation.SetFloat("isClimbAnim", 1);
                playerMove.onLadder = true;
                Move.isGrounded = false;
                InvisibleWall.SetActive(true);
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
