using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{

    [Header("DashScripts")]
    private float deathDistance = 2f; 
    private bool isMovingDown = false; 
    private float maxPosY;

    void Start()
    {
        maxPosY = transform.position.y;   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < maxPosY)
        {
            isMovingDown = true; 
        }

        if (isMovingDown && transform.position.y > maxPosY)
        {
            maxPosY = transform.position.y; 
        }

        float distanceTraveled = Mathf.Max(0, maxPosY - transform.position.y); 

        if (distanceTraveled > deathDistance)
        {
            Die(); // Запускаем "смерть" персонажа
        }
    }
    public void Die()
    {
        print("Ты умер");
    }
}
