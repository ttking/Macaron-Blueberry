using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : PooledObject {
    ParticleSystem ps;
    public int emissionAmount = 1;
	// Use this for initialization
	
	// Puts particle system back into Object pool after initation
	void Update () {
        if (ps)
        {
            if (ps.particleCount <= 0)
            {
                ReturnToPool();
            }
        }
	}

    //Setup for particle system usage
    public void Setup(Transform pos)
    {
        if (!ps)
        {
            ps = GetComponent<ParticleSystem>();
        }
        else
        {
            transform.position = pos.position;
            ps.Emit(emissionAmount);
        }
    }
}
