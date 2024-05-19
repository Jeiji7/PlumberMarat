using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaunerFire : MonoBehaviour
{
    public GameObject fireSpaunOne;
    public GameObject fireSpaunTwo;
    public int fire = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            SpawnObject();
        }
    }


    private void SpawnObject()
    {
        if(fire > 1)
        {
            Instantiate(fireSpaunOne, new Vector3(-30.66f,-29.62f,-5.4f), Quaternion.identity);
            fire--;
        }
        else if (fire == 1 && StatsMario.MarioBonus <= (4200 + StatsMario._roundMario * 1000))
        {
            Instantiate(fireSpaunTwo, new Vector3(-30.66f, -29.62f, -5.4f), Quaternion.identity);
            fire--;
        }
    }
}
