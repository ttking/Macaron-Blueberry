using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    //Temporary audio  for clicking
    [SerializeField]
    private AudioClip click;
    AudioSource audioSource;

    //Selects what levels are playable and completed
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }


    // Level name

    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Click()
    {

        audioSource.PlayOneShot(click, 1f);
    }
}