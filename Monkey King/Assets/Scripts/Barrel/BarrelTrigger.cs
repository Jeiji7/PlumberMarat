using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTrigger : MonoBehaviour
{
    public Animator BarerrelAnim;
    public GameObject BarerrelPrefab;
    public PolygonCollider2D barrelCollider;
    public FollowPathUpdate followPath;

    [Header("Music")]
    public AudioClip musicGame;
    private AudioSource musicSource;

    private void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicGame;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Molot"))
        {
            BarerrelAnim.SetBool("Crash", true);
            followPath.speed = 0f;
            StartCoroutine(BarrelDestroy());
        }
    }

    public IEnumerator BarrelDestroy()
    {
        musicSource.Play();
        Time.timeScale = 0.5f;
        StatsMario.MarioPoints += 500;
        barrelCollider.enabled = false;
        yield return new WaitForSeconds(0.6f);
        Destroy(BarerrelPrefab);
        Time.timeScale = 1f;
    }


}
