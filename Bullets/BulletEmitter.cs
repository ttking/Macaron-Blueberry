﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
    public BulletCollision bulletPrefab;

    public int amountOfBullets;
    public int amountOfBlanks;
    public int fireMode = 1;
    public float speed;
    public float speedFalloffRate;
    public int repetitions;
    public int salvos;
    public int resetSalvo;
    public float primaryAngleIncrementValue = 1.0f;
    public float secondaryAngleIncrementalValue = 1.0f;
    public float cooldown;
    public float minAngle;
    public float maxAngle;
    public bool invertAngleIncrementOnMaxMinRange;
    public bool alternatingFire;
    public string target;
    public float startDelay = 2;
    private float currentAngle;
    private bool currentAltFireState;

    float time;
    float resetSalvoTime;
    float resetSalvoCooldown = 2;


    // Use this for initialization
    void Start()
    {
        startDelay += Time.time;
        if(currentAngle < minAngle)
        {
            currentAngle = minAngle;
        }else if(currentAngle > maxAngle)
        {
            currentAngle = maxAngle;
        }
        UpdateRotation(Quaternion.Euler(0, 0, currentAngle));
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= Time.time && startDelay <= Time.time)
        {
            time = Time.time + cooldown;
            Fire();
        }
        if(salvos > 0)
        {
            resetSalvoTime = Time.time + resetSalvoCooldown;
        }else if (resetSalvoTime >= Time.time)
        {
            SetAmount(resetSalvo);
        }
    }
    void Fire() // select different firing algorithm based on "fireMode" parameter, could change from int to string later on maybe?
    {
        if (salvos >= 1)
        {
            salvos--;
            switch (fireMode)
            {
                case 0:
                    //NULL do nothing
                    break;
                case 1:
                    GenericRotationalEmitterPattern();
                    break;
                case 2:
                    ShootAtTarget();
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetAmount(resetSalvo);
        }
    }
    void GenericRotationalEmitterPattern() //
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            SpawnObject(bulletPrefab);
            IncrementEmittertAngle(primaryAngleIncrementValue);
        }
        IncrementEmittertAngle(secondaryAngleIncrementalValue); //increment angle again after firing a round of bullets.
    }

    void SetAmount(int newAmount)
    {
        currentAngle = 0;
        salvos = newAmount;
    }

    void ShootAtTarget()
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            LookAtTarget();
            SpawnObject(bulletPrefab);
        }
    }
    void IncrementEmittertAngle(float givenAngle)
    {
        currentAngle += givenAngle;
        CalculateAngle();
        
    }

    void UpdateRotation(Quaternion angle)
    {
        transform.localRotation = angle;
    }
    void LookAtTarget()
    {
        Vector3 difference = FindObjectOfType<PlayerLives>().transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        UpdateRotation(Quaternion.Euler(0.0f, 0.0f, rotationZ + 180));

    }
    void SpawnObject(PooledObject prefabToSpawn)
    {
        SetSpawnedPooledObject(prefabToSpawn.GetPooledInstance<PooledObject>());
    }

    void SetSpawnedPooledObject(PooledObject entity)
    {
        if (entity)
        {
            AnimatedProjectile pulledEntity = entity.GetComponent<AnimatedProjectile>();
            pulledEntity.transform.position = transform.position;
            pulledEntity.transform.rotation = transform.rotation;
            pulledEntity.Reset(transform);

            if (alternatingFire)
            {
                pulledEntity.Alternate(currentAltFireState);

                if (currentAltFireState)
                {
                    currentAltFireState = false;
                }
                else
                {
                    currentAltFireState = true;
                }
            }
        }
        else
        {
            Debug.Log("no projectile??");
        }
    }

    void CalculateAngle()
    {
        if (minAngle > currentAngle)
        { //if minimal angle is higher then add then loop around back from the max angle
            float processedAngle = maxAngle - (currentAngle - minAngle);
            if (invertAngleIncrementOnMaxMinRange)
            {
                InvertAngleIncrement();
                currentAngle = minAngle;
            }
            else
            {
                currentAngle = processedAngle;
            }

        }
        else if (maxAngle < currentAngle)
        { // bullet going over the angle range loop around back from the min angle
            float processedAngle = minAngle + (currentAngle - maxAngle);
            if (invertAngleIncrementOnMaxMinRange)
            {
                InvertAngleIncrement();
                currentAngle = maxAngle;
            }
            else
            {
                currentAngle = processedAngle;
            }

        }

        UpdateRotation(Quaternion.Euler(0, 0, currentAngle));
    }

    void InvertAngleIncrement()
    {
        primaryAngleIncrementValue = -primaryAngleIncrementValue;
        secondaryAngleIncrementalValue = -secondaryAngleIncrementalValue;
    }
}
