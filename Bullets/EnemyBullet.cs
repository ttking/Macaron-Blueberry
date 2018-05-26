using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : PooledObject {

    [SerializeField] private float speed;
    Vector2 _direction;
    bool isReady;


    private ParticleSpawner particleSpawner;

    // Sets variables on awake
    private void Awake()
    {
        particleSpawner = GetComponent<ParticleSpawner>();

        speed = 5f;

        isReady = false;
    }

    // Sets direction of the bullet
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }

    // Updates the direction and boundaries
    void Update()
    {

        if (isReady)
        {
            Vector2 newDirection = _direction * speed * Time.deltaTime;
            transform.position = new Vector2(transform.position.x + newDirection.x, transform.position.y + newDirection.y);
                
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if((transform.position.x < min.x) || (transform.position.x > max.x) || 
                 (transform.position.y < min.y) || (transform.position.y > max.y))  
                    {
               ReturnToPool();
            }
        }
    }

    //On collision trigger spawn particles and return to pool
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tag)
        {
            if (particleSpawner)
            {
                particleSpawner.InstantiateParticles();
            }
           ReturnToPool();
        }
    }


}
