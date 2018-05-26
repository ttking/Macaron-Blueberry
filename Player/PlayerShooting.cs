using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private bool shoot;
    private bool shootSecondary;

    public PooledObject primaryProjectile;
    public PooledObject secondaryProjectile;
    public Transform muzzle;

    [SerializeField]
    private  float timeBetweenShots;
    [SerializeField]
    private  float timeBetweenSecondaryShots;
    private float shotCounter;
    private float secondaryShotCounter;


    private void Start()
    {
        shoot = false;
    }
    
    // Updates shooting and secondary shooting 
    public void Update()
    {
        if (shoot == true)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter < 0)
            {
                shotCounter += timeBetweenShots;
                ShootPrefab(primaryProjectile);
            }
        }

        if (shootSecondary == true)
        {
            secondaryShotCounter -= Time.deltaTime;
            if (secondaryShotCounter < 0)
            {
                secondaryShotCounter += timeBetweenSecondaryShots;
                ShootPrefab(secondaryProjectile);
            }
        }
    }

    // Instantiate projectile through Object pool
    void ShootPrefab(PooledObject prefab)
    {
        PooledObject spawnedProjectile = prefab.GetPooledInstance<PooledObject>();
        spawnedProjectile.GetComponent<BaseProjectile>().ResetProjectileVariables(muzzle);
    }

    //shooting toggle
    public void Shooting()
    {
        shoot = true;
    }


    //Secondary Shooting toggle
    public void ShootingSecondary()
    {
        shootSecondary = true;
    }

    //stop shooting toggle
    public void StopShooting()
    {
        shoot = false;
    }

    // Stop shooting secondary toggle
    public void StopShootingSecondary()
    {
        shootSecondary = false;
    }
}
