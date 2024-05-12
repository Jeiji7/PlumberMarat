using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenuUI : MonoBehaviour
{
    public GameObject developer;
    public GameObject leaderBoard;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void DeveloperCreditsEnter()
    {
        developer.SetActive(true);
    }
    public void DeveloperCreditsExit()
    {
        developer.SetActive(false);
    }
    public void MenuTwo()
    {
        SceneManager.LoadScene("GameSelection");
    }
    public void LeaderBoardEnter()
    {
        leaderBoard.SetActive(true);
    }
    public void LeaderBoardExit()
    {
        leaderBoard.SetActive(false);
    }
}
