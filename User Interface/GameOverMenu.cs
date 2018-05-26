using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    private bool GameIsOver = false;

    private PlayerLives playerLives;

    private Canvas GameoverCanvas;

    private string menuSceneName = "StartMenu";


    // Use this for initialization
    void Start () {
        GameoverCanvas = GetComponent<Canvas>();

        GameoverCanvas.enabled = false;
        GameIsOver = false;
        playerLives = FindObjectOfType<PlayerLives>();
    }

    // checks if its gameover
    public void Update()
    {
        GameOverCheck();
    }

    // Trigger game over canvas
    void GameOverCheck()
    {
        if(playerLives.currentLives <= 0)
        {
            GameOver();
        }
    }

    // Enables gameover
    public void GameOver()
    {
        GameIsOver = true;
        GameoverCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    // Resumes game
    public void Resume()
    {
        GameIsOver = false;
        GameoverCanvas.enabled = false;
        Time.timeScale = 1f;
    }

    // Retry level
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Load main menu
    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
