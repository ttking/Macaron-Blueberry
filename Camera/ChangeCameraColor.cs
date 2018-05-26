using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraColor : MonoBehaviour {

    new Camera camera;
    Color backgroundColor;
    float timer;

	// Use this for initialization
	void Start () {
        camera = Camera.main;
        backgroundColor = camera.backgroundColor;
        timer = Time.time + 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (backgroundColor != camera.backgroundColor)
        {
            camera.backgroundColor = Color.Lerp(camera.backgroundColor, backgroundColor, 4 * Time.deltaTime);
        }
        else
        {
            backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
