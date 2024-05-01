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
    //public BoxCollider2D groundCollider;
    public static bool isGrounded;


    public bool onLadder;
    public bool canHorizontalMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        float moveLadder = Input.GetAxis("Vertical");
        
        if (canHorizontalMove)
        {
            rb.velocity = new Vector2(move * speedPlayer, rb.velocity.y);

            if (move < 0)
            { 
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (move > 0)
                transform.localScale = new Vector3(1, 1, 1);

            //isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCollider.size, 90, groundLayer);
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

    }


}
