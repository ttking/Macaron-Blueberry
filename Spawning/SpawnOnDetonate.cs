using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDetonate : MonoBehaviour {
    public GameObject ToSpawn;
    public float timer = 2;
	// Use this for initialization
	void Start () {
        timer += Time.time;
        GetComponent<ParticleSystem>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(timer >= Time.time)
        {
            Instantiate(ToSpawn, transform);
            Destroy(this.gameObject);
        }

	}
}
