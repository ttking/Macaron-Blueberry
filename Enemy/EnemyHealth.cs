using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] private Image healthbar;
    public float currentEnemyHealth = 0f;
    private float maxEnemyHealth = 600;

    private ScreenShake screenShake;
    private EnemyDeath deathRoutine;

    public GameObject[] BossAttacks = new GameObject[3];

    // Checks enemy health and gets the screenshake component
    private void Start()
    {
        screenShake = Camera.main.GetComponent<ScreenShake>();
        currentEnemyHealth = maxEnemyHealth;
        deathRoutine = GetComponent<EnemyDeath>();
    }

    private void Update()
    {

    }

    // Lower boss health when playerbullet hits
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBullet")
        {
            EnemyHealthDown();
        }
    }

    // Enemy health lost
    public void EnemyHealthDown()
    {
        screenShake.Shake(0.05f, -20f);
        currentEnemyHealth -= 1f;
        float calculateHealth = currentEnemyHealth / maxEnemyHealth;
        SetHealth(calculateHealth);

        if (currentEnemyHealth <= 400 && currentEnemyHealth >= 201)
        {
            // swap to bullet pattern
            BossAttacks[0].SetActive(false);
            BossAttacks[1].SetActive(true);
        }

        if (currentEnemyHealth <= 200)
        {
            BossAttacks[1].SetActive(false);
            BossAttacks[2].SetActive(true);
            //swap to bullet pattern 2
        }

        if (currentEnemyHealth <= 0f)
        {
            Debug.Log("death");
            deathRoutine.DeathRoutine();
            Destroy(this.gameObject);
            EventManager.TriggerEvent("LevelWon");
        }
        deathRoutine.OnHitAudio();
    }
    
    // Healthbar filled amount
    void SetHealth(float enemyHealth)
    {
        healthbar.fillAmount = enemyHealth;
    }
    
}
