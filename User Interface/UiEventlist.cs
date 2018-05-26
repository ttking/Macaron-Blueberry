using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiEventlist : MonoBehaviour
{

    private PauseMenu pauseMenu;

    [SerializeField]
    private AudioClip click;
    AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        pauseMenu = GetComponent<PauseMenu>();
    }

    // starts checking if events are called
    void OnEnable()
    {
        EventManager.StartListening("PauseGame", PauseGameToggle);
    }

    // Disable these events in case an object gets destroyed ( Else memory leak is possible )
    void OnDisable()
    {
        EventManager.StopListening("PauseGame", PauseGameToggle);
    }

    // turns pause menu on / off
    void PauseGameToggle()
    {
        pauseMenu.PauseToggle();
    }

    public void Click()
    {

        audioSource.PlayOneShot(click, 1f);
    }
}
