using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Animation")]
    public Animator MarioAnimation;
    public static bool LadderFinal = false;

    [Header("Attack")]
    public Animator MolotAnim;
    public GameObject Molot;

    [Header("Move")]
    public float speedPlayer = 30;
    public int PlayerLadder = 5;
    private Rigidbody2D rb;
    public static Transform tr;

    [Header("Floot")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public static bool isGrounded;

    public bool isJumping = false;

    [Header("Ladder")]
    public static bool onLadder;
    public bool canHorizontalMove = true;

    [Header("Отскок от стены")]
    public bool isTouchingWall = false; // открывает доступ к отскоку
    public bool canTouchingWall = true; //отслеживает можно ли нам взаимодействовать со стеной
    public float wallJumpForce = 0.9f; // Сила отскока от стены

    private bool isWallJumping = false; // блокировка движений при отскоке
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && canTouchingWall)
        {
            isTouchingWall = true;
        }
    }

    void Update()
    {
        float moveLadder = Input.GetAxis("Vertical");
        if (canHorizontalMove && !isWallJumping)
        {
            float move = Input.GetAxis("Horizontal");
            if (DeadPlayer.dontMove == false && AttackPlayer.activeAttack == false)
            {
                MarioAnimation.SetFloat("isMoveAnim", MathF.Abs(move));
                rb.velocity = new Vector2(move * speedPlayer, rb.velocity.y);
                // Поворот персонажа только при движении
                if (move < 0)
                    tr.localScale = new Vector3(-1, 1, 1);
                else if (move > 0)
                    tr.localScale = new Vector3(1, 1, 1);
            }
            else if(DeadPlayer.dontMove == false && AttackPlayer.activeAttack == true)
            {
                MarioAnimation.SetFloat("AttackMoveMario", MathF.Abs(move));
                rb.velocity = new Vector2(move * speedPlayer, rb.velocity.y);
                // Поворот персонажа только при движении
                if (move < 0)
                    tr.localScale = new Vector3(-1, 1, 1);
                else if (move > 0)
                    tr.localScale = new Vector3(1, 1, 1);
            }
            else if(DeadPlayer.dontMove == true && AttackPlayer.activeAttack == true)
            {
                MarioAnimation.SetFloat("AttackMoveMario", 0);
                MarioAnimation.SetBool("AttackActive", false);
                Molot.SetActive(false);
                MolotAnim.SetBool("Active", false);
                MarioAnimation.SetFloat("AttackMoveMario", 0);
                MarioAnimation.SetFloat("isMoveAnim", 0);
                MarioAnimation.SetBool("DeadMario", true);
                return;
            }
            else if (DeadPlayer.dontMove == true && AttackPlayer.activeAttack == false)
            {
                MarioAnimation.SetFloat("AttackMoveMario", 0);
                MarioAnimation.SetFloat("isMoveAnim", 0);
                return;
            }


            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);

            // Прыжок при наличии земли
            if (isGrounded && Input.GetKeyDown(KeyCode.Space) && AttackPlayer.activeAttack == false)
            {
                StartCoroutine(Jumping());
            }
        }

        // Управление движением по лестнице
        if (onLadder && AttackPlayer.activeAttack == false && DeadPlayer.dontMove == false)
        {
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                MarioAnimation.SetFloat("isClimbAnim", 1);
            }
            else
            {
                MarioAnimation.SetFloat("isClimbAnim", 0);
                MarioAnimation.SetBool("isLadderAnim", true);
            }
            canHorizontalMove = false;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, moveLadder * PlayerLadder);
            
        }
        else
        {
            MarioAnimation.SetBool("isLadderAnim", false);
            canHorizontalMove = true;
            rb.gravityScale = 2.2f;
        }

        
        // Отскок от стены
        if (isTouchingWall && !isWallJumping && !isGrounded)
        {
            canTouchingWall = false;
            if (tr.localScale.x > 0) // Если персонаж смотрит вправо
                tr.localScale = new Vector3(-1, 1, 1); // Меняем направление на влево
            else // Если персонаж смотрит влево
                tr.localScale = new Vector3(1, 1, 1); // Меняем направление на вправо
            StartCoroutine(EnableWallJump());
        }
        isTouchingWall = false;

    }

    // Включение возможности отскока от стены после некоторого времени
    private IEnumerator EnableWallJump()
    {
        isWallJumping = true;
        MarioAnimation.SetFloat("isJumpAnim", 1);
        rb.velocity = new Vector2(tr.localScale.x * wallJumpForce, rb.velocity.y);
        yield return new WaitForSeconds(0.3f); // Измените время по вашему усмотрению
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        MarioAnimation.SetFloat("isJumpAnim", 0);
        canTouchingWall = true;
        isWallJumping = false;
    }
    private IEnumerator Jumping()
    {
        MarioAnimation.SetFloat("isJumpAnim", 1);
        rb.AddForce(new Vector2(0, 2800));
        yield return new WaitForSeconds(0.72f);
        MarioAnimation.SetFloat("isJumpAnim", 0);
        MarioAnimation.SetBool("finalJump", true);
        yield return new WaitForSeconds(0.08f);
        MarioAnimation.SetBool("finalJump", false);
    }

}
