using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionRounds : MonoBehaviour
{
    public StatsMario stats;
    public bool activeFinal = false;
    public GameObject WallRounds;
    public GameObject Key;
    [Header("Music")]
    public AudioClip musicGame;
    private AudioSource musicSource;
    public MusicGames musics;

    public Transform MarioPos; 
    public Transform AigulPos;
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
        if (AigulPos.position.x < MarioPos.position.x)
        {
            AigulPos.localScale = new Vector3(1, 1, 1);
            Move.tr.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            AigulPos.localScale = new Vector3(-1, 1, 1);
            Move.tr.localScale = new Vector3(1, 1, 1);
        }
        musics.musicSource.Stop();
        musicSource.Play();
        StatsMario.Active = false;
        Key.SetActive(true);
        WallRounds.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        StatsMario.Active = true;
        stats.RefreshBonus();
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene((currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
}
