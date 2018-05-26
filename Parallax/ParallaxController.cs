using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {
    public List<PooledObject> layerList = new List<PooledObject>();
    
	// Use this for initialization
    // List for the background layers
	void Start () {
        for (int i = layerList.Count - 1; i > 0 -1; i--)
        {
            ParallaxLayer newLayer = Instantiate(new ParallaxLayer());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
