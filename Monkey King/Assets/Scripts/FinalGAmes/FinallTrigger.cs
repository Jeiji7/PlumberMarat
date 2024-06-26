using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinallTrigger : MonoBehaviour
{
    public StatsMario stats;
    public bool activeFinal = false;
    public GameObject Love;
    [Header("Music")]
    public AudioClip musicGame;
    private AudioSource musicSource;
    public MusicGames musics;
    private void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicGame;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activeFinal = true;
        }
    }
    private void Update()
    {
        if (activeFinal == true)
        {
            activeFinal = false;
            StartCoroutine(Finish());
        }
    }

    private IEnumerator Finish()
    {
        musics.musicSource.Stop();
        musicSource.Play();
        StatsMario.Active = false;
        Love.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        StatsMario.Active = true;
        stats.FinishRound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
