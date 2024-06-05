using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour
{
    [Header("Menu")]
    public GameObject DeadScreen;
    public StatsMario stats;
    public GameDataManager gameDataManager;
    [Header("DeadScript")]
    public bool DeadOne = true;
    public Animator MarioAnimation;
    private float deathDistance = 2.75f;
    private bool isMovingDown = false;
    private float maxPosY;
    public static bool dontMove = false; // Mario нельзя двигаться при смерти
    public static bool marioDead = false; //Чтобы 100 очков не защитывало 

    [Header("Music")]
    public AudioClip musicGame;
    private AudioSource musicSource;
    public MusicGames musics;
    void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicGame;
        marioDead = false;
        dontMove = false;
        Time.timeScale = 1;
        maxPosY = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && DeadOne == true)
        {
            DeadOne = false;
            dontMove = true;
            marioDead = true;
            Move.onLadder = false;
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
            print(distanceTraveled);
            Vector3 deathPosition = transform.position;
            Move.tr.position = new Vector3(deathPosition.x, Move.tr.position.y, Move.tr.position.z);
            dontMove = true;
            StartCoroutine(Die()); // Запускаем "смерть" персонажа
        }
    }
    public IEnumerator Die()
    {
        musics.musicSource.Stop();
        musicSource.Play();
        print("Ты умер");
        MarioAnimation.SetFloat("isClimbAnim", 0);
        MarioAnimation.SetBool("isLadderAnim", false);
        MarioAnimation.SetBool("DeadMario", true);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
        StatsMario._healthMario -= 1;
        
        if (StatsMario._healthMario == 0)
        {
            //float currentScore = StatsMario.MarioPoints;
            //int currentRound = StatsMario._roundMario;
            //PlayerPrefs.SetFloat("CurrentScore", currentScore);
            //PlayerPrefs.SetInt("CurrentRound", currentRound);
            gameDataManager.SaveData(StatsMario.MarioPoints, StatsMario._roundMario);
            DeadScreen.SetActive(true);
            yield return new WaitForSecondsRealtime(4f);
            stats.RefreshStats();
            SceneManager.LoadScene("GameSelection");
        }
        else
        {
            stats.RefreshBonus();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
