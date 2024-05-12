using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameTwo : MonoBehaviour
{
    public GameObject lvls;
   public void LvlsEnter()
    {
        lvls.SetActive(true);
    }
    public void LvlsExit()
    {
        lvls.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameSceneNumOne");
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
