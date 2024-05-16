using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTrigger : MonoBehaviour
{
    public Animator BarerrelAnim;
    public GameObject BarerrelPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Molot"))
        {
            BarerrelAnim.SetBool("LadderBarrel", true);
            StartCoroutine(BarrelDestroy());
        }
    }

    public IEnumerator BarrelDestroy()
    {
        StatsMario.MarioPoints += 500;
        yield return new WaitForSeconds(0.6f);
        Destroy(BarerrelPrefab);
    }
   
}
