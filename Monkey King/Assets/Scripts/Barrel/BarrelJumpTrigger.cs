using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelJumpTrigger : MonoBehaviour
{
    public PolygonCollider2D BarrelCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Move.onLadder == false && DeadPlayer.marioDead == false)
        {
            StatsMario.MarioPoints += 100;
            BarrelCollider.enabled = false;
        }
    }
}
