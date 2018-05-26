using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinionWeapon : MonoBehaviour {

    [SerializeField] private PooledObject bullet;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float cooldown;


	// Use this for initialization
	void Start () {
        InvokeRepeating("FireBullet", cooldown, cooldown);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Enemy fires bullet at player
    void FireBullet()
    {
        GameObject player = GameObject.Find("player");
        
        if(player != null)
        {
            //muzzle.GetComponent<LookAtTarget>().UpdateRotationToNewTargetPosition();
            ShootPrefab(bullet); 
        }
    }

    void ShootPrefab(PooledObject prefab)
    {
        PooledObject spawnedProjectile = prefab.GetPooledInstance<PooledObject>();
        spawnedProjectile.GetComponent<BaseProjectile>().ResetProjectileVariables(muzzle);
    }
}
