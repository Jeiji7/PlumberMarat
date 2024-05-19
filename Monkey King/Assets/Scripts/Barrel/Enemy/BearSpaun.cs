using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpaun : MonoBehaviour
{
    public Animator BearAnim;
    public GameObject CoroutineGameObjectOne;
    public GameObject CoroutineGameObjectTwo;
    public GameObject[] objectsToSpawn;
    public int lastSpawnedObject = 8;
    public int currentSpawnedObject = 9;
    public int randomIndex;
    public int checkPointBonus = 3;
    public bool Active = true;
    public bool DoubleActive = false;

    private void Update()
    {
        SpawnRandomObject();
    }

    private void SpawnRandomObject()
    {
        if (checkPointBonus == 3 && StatsMario.MarioBonus <= 5000 + 1000 * StatsMario._roundMario && Active == true)
        {
            Active = false;
            StartCoroutine(CoroutineOneSpaun());
            checkPointBonus--;
        }
        else if (StatsMario.MarioBonus <= 4000 + 1000 * StatsMario._roundMario && checkPointBonus == 2 && Active == true)
        {
            Active = false;
            StartCoroutine(CoroutineTwoSpaun());
            checkPointBonus--;
        }
        else if (StatsMario.MarioBonus <= 3000 + 1000 * StatsMario._roundMario && checkPointBonus == 1 && Active == true)
        {
            Active = false;
            StartCoroutine(CoroutineOneSpaun());
            checkPointBonus--;
        }
        else if (Active == true)
        {
            Active = false;
            randomIndex = Random.Range(0, objectsToSpawn.Length);
            // Повторно выбираем элемент, пока не получим что-то отличное от последнего и предпоследнего объектов
            while (randomIndex == lastSpawnedObject || randomIndex == currentSpawnedObject)
            {
                randomIndex = Random.Range(0, objectsToSpawn.Length);
            }
            StartCoroutine(CoroutineTreeDefalt());
        }
    }
    private IEnumerator CoroutineOneSpaun()
    {
        BearAnim.SetBool("ThrowTwo", true);
        yield return new WaitForSeconds(0.50f);
        Instantiate(CoroutineGameObjectOne, new Vector3(-28.81f, -5.22f, -5.318298f), Quaternion.identity);
        BearAnim.SetBool("ThrowTwo", false);
        BearAnim.SetBool("Champion", true);
        yield return new WaitForSeconds(2.3f);
        BearAnim.SetBool("Champion", false);
        Active = true;
    }
    private IEnumerator CoroutineTwoSpaun()
    {
        BearAnim.SetBool("ThrowTwo", true);
        yield return new WaitForSeconds(0.50f);
        Instantiate(CoroutineGameObjectTwo, new Vector3(-28.81f, -5.22f, -5.318298f), Quaternion.identity);
        BearAnim.SetBool("ThrowTwo", false);
        BearAnim.SetBool("Champion", true);
        yield return new WaitForSeconds(2.3f);
        BearAnim.SetBool("Champion", false);
        Active = true;
    }
    private IEnumerator CoroutineTreeDefalt()
    {
        BearAnim.SetBool("ThrowOne", true);
        yield return new WaitForSeconds(0.5f);
        // Спауним объект
        Instantiate(objectsToSpawn[randomIndex], new Vector3(-28.29f, -5.41f, -4.7f), Quaternion.identity);
        lastSpawnedObject = currentSpawnedObject;
        currentSpawnedObject = randomIndex;
        yield return new WaitForSeconds(0.4f);
        BearAnim.SetBool("ThrowOne", false);
        BearAnim.SetBool("Champion", true);
        yield return new WaitForSeconds(1.9f);
        BearAnim.SetBool("Champion", false);
        Active = true;
    }
}
