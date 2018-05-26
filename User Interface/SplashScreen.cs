using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SplashScreen : MonoBehaviour {

    public MovieTexture splashScreenTexture;
    private AudioSource audio;

    private void Start()
    {
        GetComponent<RawImage>().texture = splashScreenTexture as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = splashScreenTexture.audioClip;

        splashScreenTexture.Play();
        audio.Play();
    }

    void Update()
    {
        if (!splashScreenTexture.isPlaying)
        {
            Application.LoadLevel(1);
        }
    }

}
