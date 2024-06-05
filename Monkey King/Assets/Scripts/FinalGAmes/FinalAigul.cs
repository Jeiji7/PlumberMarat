using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalAigul : MonoBehaviour
{
    public static bool ActiveStats = true;
    public StatsMario stats;
    public bool activeFinal = false;
    public GameObject Love;
    public GameObject Key;
    public GameObject Wall;
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
            ActiveStats = false;
            activeFinal = false;
            DeadPlayer.dontMove = true;
            StartCoroutine(Finish());
        }
    }

    private IEnumerator Finish()
    {
        musics.musicSource.Stop();
        musicSource.Play();
        Key.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        Key.transform.position = new Vector3(-11.6f, -26.9f, 0);
        yield return new WaitForSeconds(0.22f);
        Key.transform.position = new Vector3(-10.6f, -26.9f, 0);
        yield return new WaitForSeconds(0.22f);
        Key.transform.position = new Vector3(-9.1f, -26.9f, 0);
        yield return new WaitForSeconds(0.22f);
        Key.SetActive (false);
        yield return new WaitForSeconds(0.4f);
        Wall.SetActive(false);
        Love.SetActive(true);
        yield return new WaitForSeconds(7);
        ActiveStats = true;
        stats.FinishRound();
        SceneManager.LoadScene("GameSceneNumOne");
    }

}
