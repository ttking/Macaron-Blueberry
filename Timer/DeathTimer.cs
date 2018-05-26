using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour {
    float timer = 2;
	// Use this for initialization
	void Start () {
        timer += Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer <= Time.time)
        {
            Destroy(this.gameObject);
        }
	}
}
