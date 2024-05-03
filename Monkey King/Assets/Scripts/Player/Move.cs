using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speedPlayer = 30;
    public int PlayerLadder = 5;
    private Rigidbody2D rb;


    public Transform groundCheck;
    public LayerMask groundLayer;
    public static bool isGrounded;


    public bool onLadder;
    public bool canHorizontalMove = true;

    [Header("Отскок от стены")]
    public bool isTouchingWall = false;
    public float wallJumpForce = 3f; // Сила отскока от стены
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter()
    {
        transform.Translate(transform.position);    
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isWallJump = true;
            Vector2 wallJumpDirection = new Vector2(3f, 3f); // Вектор направления отталкивания
            rb.velocity = new Vector2(wallJumpDirection.x, wallJumpDirection.y);
        }
    }
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        float moveLadder = Input.GetAxis("Vertical");
        if (canHorizontalMove)
        {
            rb.velocity = new Vector2(move * speedPlayer, rb.velocity.y);

            if (move < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (move > 0)
                transform.localScale = new Vector3(1, 1, 1);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, 2400));
            }
        }
        if (onLadder == true)
        {
            canHorizontalMove = false;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, moveLadder * PlayerLadder);
        }
        else
        {
            canHorizontalMove = true;
            rb.gravityScale = 2.2f;
        }
        if (isTouchingWall)
        {
            isTouchingWall = false;
        }
    }
}
