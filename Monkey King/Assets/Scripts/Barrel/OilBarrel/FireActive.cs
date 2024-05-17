using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive : MonoBehaviour
{
    public GameObject fire;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            print("Работает");
            fire.SetActive(true);
        }
    }
}
