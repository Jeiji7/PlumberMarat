using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Animation")]
    public Animator MarioAnimation;
    public static bool LadderFinal = false;

    [Header("������")]
    public float speedPlayer = 30;
    public int PlayerLadder = 5;
    private Rigidbody2D rb;
    public static Transform tr;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public static bool isGrounded;

    public bool isJumping = false;

    public bool onLadder;
    public bool canHorizontalMove = true;

    [Header("������ �� �����")]
    public bool isTouchingWall = false; // ��������� ������ � �������
    public bool canTouchingWall = true; //����������� ����� �� ��� ����������������� �� ������
    public float wallJumpForce = 1f; // ���� ������� �� �����

    private bool isWallJumping = false; // ���������� �������� ��� �������
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
            MarioAnimation.SetFloat("isMoveAnim", MathF.Abs(move));
            rb.velocity = new Vector2(move * speedPlayer, rb.velocity.y);
            // ������� ��������� ������ ��� ��������
            if (move < 0)
                tr.localScale = new Vector3(-1, 1, 1);
            else if (move > 0)
                tr.localScale = new Vector3(1, 1, 1);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);

            // ������ ��� ������� �����
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, 2800));
            }
            //if(isGrounded == false)
            //{
            //    MarioAnimation.SetBool("isJumpAnim", true);
            //}
            //else
            //{
            //    MarioAnimation.SetBool("isJumpAnim", false);
            //}
        }

        // ���������� ��������� �� ��������
        if (onLadder)
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

        // ������ �� �����
        if (isTouchingWall && !isWallJumping && !isGrounded)
        {
            canTouchingWall = false;
            if (tr.localScale.x > 0) // ���� �������� ������� ������
                tr.localScale = new Vector3(-1, 1, 1); // ������ ����������� �� �����
            else // ���� �������� ������� �����
                tr.localScale = new Vector3(1, 1, 1); // ������ ����������� �� ������
            StartCoroutine(EnableWallJump());
        }
        isTouchingWall = false;
    }

    // ��������� ����������� ������� �� ����� ����� ���������� �������
    private IEnumerator EnableWallJump()
    {
        isWallJumping = true;
        MarioAnimation.SetBool("isJumpAnim", true);
        rb.velocity = new Vector2(tr.localScale.x * wallJumpForce, rb.velocity.y);
        yield return new WaitForSeconds(0.3f); // �������� ����� �� ������ ����������
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        MarioAnimation.SetBool("isJumpAnim", false);
        canTouchingWall = true;
        isWallJumping = false;
    }
}
