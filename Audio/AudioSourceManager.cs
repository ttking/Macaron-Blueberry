using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour {
    private List<AudioSource> idleAudioSourcePlayers = new List<AudioSource>();
    private List<AudioSource> playingAudioSourcePlayers = new List<AudioSource>();

    public void PlayIncomingSource(AudioClip audio) {
        if (audio != null)
        {
            if (playingAudioSourcePlayers.Count >= 1) // clean up any audioPlayers that are done playing audio.
            {
                PlayingAudioSourceCleanUp();
            }

            if (idleAudioSourcePlayers.Count >= 1)   // there is an available audioSourcePlayer
            {
                idleAudioSourcePlayers[0].clip = audio;
            }
            else
            {                                  // there is no available audioSourcePlayer
                AudioSource newAudioSource = new AudioSource
                {
                    clip = audio
                };
                idleAudioSourcePlayers.Add(newAudioSource);
            }

            idleAudioSourcePlayers[0].Play();
            AudioSource holdSource = idleAudioSourcePlayers[0];
            idleAudioSourcePlayers.RemoveAt(0);

            playingAudioSourcePlayers.Add(holdSource);
        }
        else
        {
            Debug.Log("noAudioClip");
        }

    }

    private void PlayingAudioSourceCleanUp()
    {
        for (int i = 0; i < playingAudioSourcePlayers.Count - 1; i++)
        {
            if (playingAudioSourcePlayers[i].isPlaying == false)
            {
                AudioSource holdSource = playingAudioSourcePlayers[i];
                playingAudioSourcePlayers.RemoveAt(i);
                idleAudioSourcePlayers.Add(holdSource);
            }
        }
    }
}
