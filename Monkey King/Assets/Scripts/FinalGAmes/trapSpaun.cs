using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapSpaun : MonoBehaviour
{
    public GameObject barrel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            barrel.SetActive(true);
        }
    }
}
