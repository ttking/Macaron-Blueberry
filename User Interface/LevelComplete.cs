using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{

    public Canvas completeMenu;

    public string menuSceneName = "StartMenu";

    public string nextLevel = "test2";
    public int levelToUnlock = 2;

    Animator anim;

    //Get the menu component and turn it off
    private void Start()
    {
        completeMenu = completeMenu.GetComponent<Canvas>();
        Time.timeScale = 1f;
        completeMenu.enabled = false;
    }

    // Turn on level won canvas and pause game
    public void LevelWon()
    {
        completeMenu.enabled = true;
        Time.timeScale = 0;
    }

    // Continue to next level
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }

    //Go to menu
    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    // Retry/Restart level
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
