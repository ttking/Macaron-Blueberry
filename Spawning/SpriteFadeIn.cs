using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFadeIn : MonoBehaviour {

    public AnimationCurve transparencyCurve;
    public AudioClip fadeInAudioClip;
    public float fadeInAudioVolume;
    public float fadeInSpeedMultiplier;
    public GameObject fadeInParticles, summonedParticles;
    public AudioSource audioSource;
    public SpriteRenderer sprite;
    public BoxCollider2D spriteCollider;
    public float finishedTime = 1f;

    private InternalTimer timer;

    // Use this for initialization
    void Start () {
        timer = GetComponent<InternalTimer>();

        if(!sprite)
            sprite = GetComponent<SpriteRenderer>();

        if (!audioSource)
            audioSource = GetComponent<AudioSource>();

        if(!spriteCollider)
            timer.enabled = false;

        spriteCollider.enabled = false;
        timer.timerMultiplier = fadeInSpeedMultiplier;
        sprite.color = new Color(1, 1, 1, 0);
        Instantiate(fadeInParticles, transform.position, transform.rotation, null);
        audioSource.PlayOneShot(fadeInAudioClip, fadeInAudioVolume);
    }
	
	// Update is called once per frame
	void Update () {
		if(timer.currentInternalTime <= finishedTime)
        {
            sprite.color = new Color(1, 1, 1, transparencyCurve.Evaluate(timer.currentInternalTime));   // set alpha to the current keyframe in the curve.
        }
        else
        {
            sprite.color = new Color(1, 1, 1, transparencyCurve.Evaluate(1));
            spriteCollider.enabled = true;                                               // enable collider when fully opague.
            Instantiate(summonedParticles, transform.position, transform.rotation, null);
            timer.enabled = false;
            this.enabled = false;            
            // we're done here so turn off the script.
        }
	}
}
