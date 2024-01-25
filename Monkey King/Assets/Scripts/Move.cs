using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speedPlayer = 30;
    public int PlayerLadder = 5;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

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

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, 2200));
            }
        }

        //isLadder = Physics2D.OverlapCircle(ladderCheck.position, 0.2f, ladderLayer);
        if (onLadder == true)
        {
            canHorizontalMove = false;
            //rb.velocity.x = 0f;   
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
