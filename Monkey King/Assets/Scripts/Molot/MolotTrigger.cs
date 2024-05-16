using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotTrigger : MonoBehaviour
{
    public static bool ActiveMolot = false;
    public GameObject Molot;
    private void Start()
    {
        ActiveMolot = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActiveMolot = true;
            Destroy(Molot);
        }
    }
}
