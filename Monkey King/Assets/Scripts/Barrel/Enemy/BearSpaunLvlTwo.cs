using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpaunLvlTwo : MonoBehaviour
{
    public Animator BearAnim;
    public GameObject CoroutineGameObjectTwo;
    public Transform SpaunBearRightBarrel;
    public Transform SpaunVerticalBarrel;
    public Transform SpaunBearLeftBarrel;
    public GameObject[] objectsToSpawnRight;
    public GameObject[] objectsToSpawnLeft;
    public int lastSpawnedObjectLeft = 8;
    public int lastSpawnedObjectRight = 8;
    public int currentSpawnedObjectLeft = 9;
    public int currentSpawnedObjectRight = 9;
    public int randomIndexRight;
    public int randomIndexLeft;
    public int checkPointBonus = 3;
    public bool Active = true;
    public bool DoubleActive = false;

    private void Update()
    {
        SpawnRandomObject();
    }

    private void SpawnRandomObject()
    {
        if (checkPointBonus == 3 && Active == true)
        {
            Active = false;
            randomIndexRight = Random.Range(0, objectsToSpawnRight.Length);
            // Повторно выбираем элемент, пока не получим что-то отличное от последнего и предпоследнего объектов
            while (randomIndexRight == lastSpawnedObjectRight || randomIndexRight == currentSpawnedObjectRight)
            {
                randomIndexRight = Random.Range(0, objectsToSpawnRight.Length);
            }
            checkPointBonus--;
            StartCoroutine(CoroutineOneSpaun());
        }
        else if (checkPointBonus == 2 && Active == true)
        {
            Active = false;
            checkPointBonus--;
            StartCoroutine(CoroutineTwoSpaun());
        }
        else if (checkPointBonus == 1 && Active == true)
        {
            Active = false;
            randomIndexLeft = Random.Range(0, objectsToSpawnLeft.Length);
            // Повторно выбираем элемент, пока не получим что-то отличное от последнего и предпоследнего объектов
            while (randomIndexLeft == lastSpawnedObjectLeft || randomIndexLeft == currentSpawnedObjectLeft)
            {
                randomIndexLeft = Random.Range(0, objectsToSpawnLeft.Length);
            }
            checkPointBonus--;
            StartCoroutine(CoroutineTreeSpaun());
        }

    }
    private IEnumerator CoroutineOneSpaun()
    {
        Vector3 pos = SpaunBearRightBarrel.transform.position;
        BearAnim.SetBool("ThrowOne", true);
        yield return new WaitForSeconds(0.5f);
        // Спауним объект
        Instantiate(objectsToSpawnRight[randomIndexRight], pos, Quaternion.identity);
        lastSpawnedObjectRight = currentSpawnedObjectRight;
        currentSpawnedObjectRight = randomIndexRight;
        yield return new WaitForSeconds(0.4f);
        BearAnim.SetBool("ThrowOne", false);
        BearAnim.SetBool("Champion", true);
        yield return new WaitForSeconds(1.9f);
        BearAnim.SetBool("Champion", false);
        Active = true;
    }
    private IEnumerator CoroutineTwoSpaun()
    {
        Vector3 pos = SpaunVerticalBarrel.transform.position;
        BearAnim.SetBool("ThrowTwo", true);
        yield return new WaitForSeconds(0.50f);
        Instantiate(CoroutineGameObjectTwo, pos, Quaternion.identity);
        BearAnim.SetBool("ThrowTwo", false);
        BearAnim.SetBool("Champion", true);
        yield return new WaitForSeconds(2.3f);
        BearAnim.SetBool("Champion", false);
        Active = true;
    }
    private IEnumerator CoroutineTreeSpaun()
    {
        Vector3 pos = SpaunBearLeftBarrel.transform.position;
        Quaternion rotationToSpawn = Quaternion.Euler(0, 180, 0);
        BearAnim.SetBool("ThrowTree", true);
        yield return new WaitForSeconds(0.5f);
        // Спауним объект
        //Instantiate(objectsToSpawnLeft[randomIndexLeft], pos, Quaternion.identity);
        Instantiate(objectsToSpawnLeft[randomIndexLeft], pos, rotationToSpawn);
        lastSpawnedObjectLeft = currentSpawnedObjectLeft;
        currentSpawnedObjectLeft = randomIndexLeft;
        yield return new WaitForSeconds(0.4f);
        BearAnim.SetBool("ThrowTree", false);
        BearAnim.SetBool("Champion", true);
        yield return new WaitForSeconds(1.9f);
        BearAnim.SetBool("Champion", false);
        Active = true;
        checkPointBonus = 3;
    }
}
