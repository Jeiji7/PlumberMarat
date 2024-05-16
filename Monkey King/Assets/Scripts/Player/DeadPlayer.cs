using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour
{
    public StatsMario stats;
    [Header("DeadScript")]
    public Animator MarioAnimation;
    private float deathDistance = 2.5f;
    private bool isMovingDown = false;
    private float maxPosY;
    public static bool dontMove = false;

    void Start()
    {
        dontMove = false;
        Time.timeScale = 1;
        maxPosY = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(Die());
        }
    }
    void Update()
    {
        if (transform.position.y < maxPosY)
        {
            isMovingDown = true;
        }

        if (isMovingDown && transform.position.y > maxPosY || Exit_Lader.isDown == true)
        {
            maxPosY = transform.position.y;
        }
        float distanceTraveled = Mathf.Max(0, maxPosY - transform.position.y);
        if (distanceTraveled > deathDistance && Exit_Lader.isDown == false)
        {
            //MarioAnimation.SetFloat("isJumpingAnim", 0);
            Vector3 deathPosition = transform.position;
            Move.tr.position = new Vector3(deathPosition.x, Move.tr.position.y, Move.tr.position.z);
            dontMove = true;
            Move.onLadder = false;
            StartCoroutine(Die()); // Запускаем "смерть" персонажа
        }
    }
    public IEnumerator Die()
    {
        print("Ты умер");
        MarioAnimation.SetBool("DeadMario", true);
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        StatsMario._healthMario -= 1;
        stats.RefreshBonus();
        if (StatsMario._healthMario == 0)
        {
            float currentScore = StatsMario.MarioPoints;
            PlayerPrefs.SetFloat("CurrentScore", currentScore);
            stats.RefreshStats();
            SceneManager.LoadScene("GameSelection");
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
