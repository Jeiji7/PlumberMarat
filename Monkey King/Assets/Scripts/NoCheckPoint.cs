using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCheckPoint : MonoBehaviour
{
    public MiddleTriggerLadder midPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        midPoint.ThirdTrigger.SetActive(false);
        }
    }
}
