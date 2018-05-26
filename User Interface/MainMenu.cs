using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private string levelToLoad = "Tutorial";

    //Temporary audio  for clicking
    [SerializeField]
    private AudioClip click;
    AudioSource audioSource;

    // Load Levelselct
    public void Play()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.LoadScene(levelToLoad);
    }

    //Quit application
    public void Quit()
    {
        Application.Quit();
    }

    public void Click()
    {

        audioSource.PlayOneShot(click, 1f);
    }
}

