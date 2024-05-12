using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject Pause;
    public StatsMario Stats;
    public bool InputEscape = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InputEscape = !InputEscape;
            Pause.SetActive(InputEscape);
            if (InputEscape == false)
                Time.timeScale = 1.0f;
            else
                Time.timeScale = 0.0f;
        }
    }
    public void ExitGame()
    {
        Stats.RefreshStats();
        SceneManager.LoadScene("GameSelection");
    }
}
