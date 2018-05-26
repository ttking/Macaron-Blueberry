using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour {
    public ParticleHandler prefabParticles;

    // instatiate particles at allocated spot 
    public void InstantiateParticles()
    {
        ParticleHandler instantiatedParticles = prefabParticles.GetPooledInstance<ParticleHandler>();
        instantiatedParticles.Setup(transform);
    }
}

