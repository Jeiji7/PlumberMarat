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
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MarioAnimation.SetFloat("isClimbAnim", 1);
        }
    }

    void Update()
    {
        if (upAnimation)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                MarioAnimation.SetFloat("isClimbAnim", 0);
                MarioAnimation.SetFloat("FinalClimb", 1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                MarioAnimation.SetFloat("isClimbAnim", 0);
                MarioAnimation.SetFloat("FinalClimb", -1);
            }
        }
    }
}
