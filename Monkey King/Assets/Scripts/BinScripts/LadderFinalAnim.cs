using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderFinalAnim : MonoBehaviour
{
    public Animator MarioAnimation;
    public bool upAnimation = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            upAnimation = true;
            MarioAnimation.SetFloat("isClimbAnim", 0);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("LadderTrigger"))
        {
            MarioAnimation.SetFloat("FinalClimb", 0);
            MarioAnimation.SetFloat("isClimbAnim", 0);
            Move.LadderFinal = false;
        }
    }

    void Update()
    {
        if (upAnimation)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {

                Move.LadderFinal = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Move.LadderFinal = true;
            }
        }
    }
}
