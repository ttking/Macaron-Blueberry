using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
    public float deathClipVolume, onHitClipVolume;
    public ParticleSystem particlePrefab;
    public AudioClip deathAudioClip, onHitAudioClip;

    AudioSource deathAudioPlayer;
    AudioSource damageAudioPlayer;
	// Use this for initialization
	void Start () {
        deathAudioPlayer = GameObject.Find("EnemyDeathAudioPlayer").GetComponent<AudioSource>();
        damageAudioPlayer = gameObject.GetComponent<AudioSource>();
	}

    public void DeathRoutine()
    {
        deathAudioPlayer.PlayOneShot(deathAudioClip,deathClipVolume);
        Instantiate(particlePrefab, transform.position,transform.rotation,null);
    }
    public void OnHitAudio()
    {
        damageAudioPlayer.pitch = 1 + Random.Range(-.1f, .1f);
        damageAudioPlayer.PlayOneShot(onHitAudioClip, onHitClipVolume);
    }
}
