using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawning : MonoBehaviour {

    public enum SpawnState {Spawning, Waiting, Counting};

    public GameObject Boss;

    public Transform[] SpawnPoints;

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    private float waveCountDown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;
    private Transform previousSpawnTransform;


    // Variables to define each wave seperate
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        //public Transform enemy2;
        public int count;
        public float rate;
    }


    // start wave countdown and check for waypoints + disable boss
    void Start()
    {
        if (SpawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }

        waveCountDown = timeBetweenWaves;

        Boss.SetActive(false);
    }
    
    //change state of spawning
    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if(!EnemyIsAlive())
            {
                WaveCompleted();
                
            }

            else
            {
                return;
            }
        }


        if (waveCountDown <= 0)
        {
            if (state != SpawnState.Spawning)         
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    // Sets wave to complete and activate boss when final wave starts
    void WaveCompleted()
    {

        state = SpawnState.Counting;
        waveCountDown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Boss.SetActive(true);
        }
        else
        {
            nextWave++;
            ResetBooleans();
        }
      
    }

    // Checks if enemies are alive to then proceed the countdown and go to the next wave
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < wave.count; i++)    
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);

        }
            state = SpawnState.Waiting;

        yield break;
    }   

    // Instantiate enemy at random spawnpoint
    void SpawnEnemy (Transform enemy)
    {
        Transform sp = SpawnPoints[Random.RandomRange(0, SpawnPoints.Length)];

        for (int i = 0; i < 15; i++)
        {
            if (sp.gameObject.GetComponent<SimpleBool>().boolean == true)
            {
                sp = SpawnPoints[Random.RandomRange(0, SpawnPoints.Length)];
            }
            else
            {
                previousSpawnTransform = sp;
                sp.gameObject.GetComponent<SimpleBool>().boolean = true;
                break;
            }

        }
        Instantiate(enemy, sp.position, sp.rotation);
    }

    void ResetBooleans()
    {
        for (int i = 0; i < SpawnPoints.Length-1; i++)
        {
            SpawnPoints[i].GetComponent<SimpleBool>().boolean = false;
        }
    }


}

