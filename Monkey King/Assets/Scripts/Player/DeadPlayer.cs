using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{

    [Header("DeadScript")]
    private float deathDistance = 2f; 
    private bool isMovingDown = false; 
    private float maxPosY;

    void Start()
    {
        maxPosY = transform.position.y;   
    }

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
        print("1: " +  maxPosY);
        float distanceTraveled = Mathf.Max(0, maxPosY - transform.position.y); 
        print("2: "+ distanceTraveled);
        if (distanceTraveled > deathDistance)
        {
            Die(); // ��������� "������" ���������
        }
    }
    public void Die()
    {
        print("�� ����");
    }
}
