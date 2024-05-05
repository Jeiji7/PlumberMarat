using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{

    [Header("DeadScript")]
    private float deathDistance = 2.5f; 
    private bool isMovingDown = false; 
    private float maxPosY;

    void Start()
    {
        maxPosY = transform.position.y;   
    }

    void Update()
    {
        if (transform.position.y < maxPosY )
        {
            isMovingDown = true; 
        }

        if (isMovingDown && transform.position.y > maxPosY || Exit_Lader.isDown == true)
        {
            maxPosY = transform.position.y; 
        }
        //print("1: " +  maxPosY);
        //print("2: " + transform.position.y);
        float distanceTraveled = Mathf.Max(0, maxPosY - transform.position.y); 
        //print("3: "+ distanceTraveled);
        if (distanceTraveled > deathDistance && Exit_Lader.isDown == false)
        {
            Die(); // Запускаем "смерть" персонажа
        }
    }
    public void Die()
    {
        //print("Ты умер");
    }
}
