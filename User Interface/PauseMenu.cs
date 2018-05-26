using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool GameIsPaused = false;

    [SerializeField]
    private Canvas PauseCanvas;


    private string menuSceneName = "StartMenu";

    // Set game to play on start
    private void Start()
    {
            PauseCanvas = GetComponent<Canvas>();
            PauseCanvas.enabled = false;
            GameIsPaused = false;
    }

    // Toggle function on
    public void PauseToggle()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    //Continue game 
    public void Resume()
    {
        GameIsPaused = false;
        PauseCanvas.enabled = false;
        Time.timeScale = 1f;
    }

    //Pause game
    public void Pause()
    {
        GameIsPaused = true;
        PauseCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    //Retry level
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Load main menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
