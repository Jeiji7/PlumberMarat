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
    public void PlayGameOneLvl()
    {
        SceneManager.LoadScene("GameSceneNumOne");
    }
    public void PlayGameTwoLvl()
    {
        SceneManager.LoadScene("GameSceneNumTwo");
    }
    public void PlayGameTreeLvl()
    {
        SceneManager.LoadScene("FinalScene");
    }
    public void ExitMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
