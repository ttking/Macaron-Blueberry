using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile : BaseProjectile {

    [SerializeField]private PooledObject prefabToSpawn;
    [SerializeField]private int projectilesToSpawn;
    [SerializeField]private float secondsUntilDetonation;
    [SerializeField]private bool repeat = false;

    private float timer;
    private float angle;
    private bool detonated = false;

    protected override void Start()
    {
        base.Start();
        angle = 360 / projectilesToSpawn;
        SetTimer(secondsUntilDetonation);
    }

    protected override void Update()
    {
        base.Update();
        Detonate();
    }

    void Detonate()
    {
        if (timer < Time.time && detonated == false)
        {
            Vector3 spawnPosition = this.gameObject.transform.position;
            for (int i = 0; i < projectilesToSpawn; i++)
            {
                PooledObject spawnedProjectile = prefabToSpawn.GetPooledInstance<PooledObject>();
                spawnedProjectile.transform.position = spawnPosition;
                spawnedProjectile.transform.localRotation = Quaternion.Euler(0, 0, angle * i);
                spawnedProjectile.GetComponent<BaseProjectile>().ResetProjectileVariables(spawnedProjectile.transform);
            }
            detonated = true;
            if (repeat)
            {
                SetTimer(secondsUntilDetonation);
            }
        }
    }
    
    public override void ResetProjectileVariables(Transform newPosition)
    {
        base.ResetProjectileVariables(newPosition);
        SetTimer(secondsUntilDetonation);
        detonated = false;
    }

    private void SetTimer(float addedTime)
    {
        timer = Time.time + addedTime;
    }
}
