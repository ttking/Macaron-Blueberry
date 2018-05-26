using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour { // a class holding an audio file and corresponding name for the event manager to identify this.
    public AudioClip audioClip;
    public AudioSourceManager audioPlayer;
    public string correspondingEvent;

    private bool playedThisFrame = false;
    private float quickTimer;
    private float quickCooldown = 1;
    public AnimationCurve curvy;

    private void Start()
    {
        quickTimer = Time.time+quickCooldown;
        //listen to event
    }
    private void Update()
    {
        playedThisFrame = false;
        if(Time.time >= quickTimer)
        {
            quickTimer += quickCooldown;
            //PlayAudioOnEvent();
        }
    }

    public void PlayAudioOnEvent() // call this function on corresponding event
    {
        if (!playedThisFrame)
        {
            audioPlayer.PlayIncomingSource(audioClip);
        }
        // play audio when corresponding event is called.
    }




}
