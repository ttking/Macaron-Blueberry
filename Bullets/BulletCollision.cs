using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : PooledObject
{
    public float lifespan = 5;
    public List<string> tags;
    private Vector2 bounds = new Vector2(20, 11);
    private float timer;
    private ParticleSpawner particleSpawner;
    //private Health health;


    private void Start()
    {
        particleSpawner = GetComponent<ParticleSpawner>();
        //health = GetComponent<Health>();
    }
    void OnEnable()
    {
        timer = Time.time + lifespan;
        if (true) //removed healthcheck if health
        {

        }
        else
        {
            //health = GetComponent<Health>();
        }
    }

    private void Update()
    {
        if (timer <= Time.time)
        {
            ReturnToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < tags.Count; i++)
        {
            if (collision.tag == tags[i])
            {
                if (particleSpawner)
                {
                    particleSpawner.InstantiateParticles();
                }
                /*health.ModifyHealth(-1);
                if (health.HasHealthLeft() == false)
                {
                    ReturnToPool();
                }*/
                ReturnToPool();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < tags.Count; i++)
        {
            if (collision.transform.tag == tags[i])
            {
                if (particleSpawner)
                {
                    particleSpawner.InstantiateParticles();
                }

                ReturnToPool();
            }
        }
    }
}
