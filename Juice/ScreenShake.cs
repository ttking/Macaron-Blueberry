using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    public float shakeModfier = .005f;

    private float currentShakeStrength = 0f;
    private Vector3 cameraPos;

    // Checks camera pos
    void Start()
    {
        cameraPos = transform.position;
    }

    // Sets position and range of screenshake strength
    private void Update()
    {
        if(currentShakeStrength > 0.001)
        {
            Vector3 ShakenPos = new Vector3(Random.Range(-currentShakeStrength, currentShakeStrength), Random.Range(-currentShakeStrength, currentShakeStrength), cameraPos.z);
            transform.position = ShakenPos;
            currentShakeStrength = currentShakeStrength * ( 1 + shakeModfier * Time.deltaTime);

        }
        else
        {
            currentShakeStrength = 0;
            transform.position = cameraPos;
        }
    }

    //Modifies shake strength 
    public void Shake(float strength, float modifierOverTime)
    {
        shakeModfier = modifierOverTime;
        currentShakeStrength += strength;
    }
}
