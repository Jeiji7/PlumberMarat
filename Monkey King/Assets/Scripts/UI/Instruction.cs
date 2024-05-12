using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{

    public GameObject instruction;
    public GameObject[] gameObjects; // Публичный массив игровых объектов
    private int currentIndex = -1;

    public void EnterInstruction()
    {
        instruction.SetActive(true);
    }
    public void ExitInstruction()
    {
        instruction.SetActive(false);
    }

    public void ToggleNextObject()
    {
        if (currentIndex >= 0)
        {
            gameObjects[currentIndex].SetActive(false);
        }

        currentIndex = (currentIndex + 1) % gameObjects.Length;
        gameObjects[currentIndex].SetActive(true);
    }

    public void TogglePreviousObject()
    {
        if (currentIndex >= 0)
        {
            gameObjects[currentIndex].SetActive(false);
        }

        currentIndex = (currentIndex - 1 + gameObjects.Length) % gameObjects.Length;
        gameObjects[currentIndex].SetActive(true);
    }

}
