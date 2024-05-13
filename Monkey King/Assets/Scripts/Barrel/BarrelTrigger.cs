using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTrigger : MonoBehaviour
{
    public Animator BarerrelAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Enemy"))
        {
            print("sex");
            BarerrelAnim.SetBool("LadderBarrel", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CompareTag("Enemy"))
        {
            BarerrelAnim.SetBool("LadderBarrel", false);
        }
    }
}
