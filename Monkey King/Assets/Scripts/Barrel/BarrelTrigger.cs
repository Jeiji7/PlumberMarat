using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTrigger : MonoBehaviour
{
    private Transform tr;
    public Animator BarerrelAnim;
    public GameObject BarerrelPrefab;
    public PolygonCollider2D barrelCollider;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }
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
        barrelCollider.enabled = false;
        tr.position = new Vector3(0,0,0);
        yield return new WaitForSeconds(0.6f);
        Destroy(BarerrelPrefab);
    }
   
}
