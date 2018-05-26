using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealth : MonoBehaviour {
    private float currentEnemyHealth = 0f;
    [SerializeField]
    private float maxEnemyHealth = 10;
   
    private ScreenShake screenShake;
    private EnemyDeath enemyDeath;

    // Enabled screenshakes and sets health
    private void Start()
    {
        enemyDeath = GetComponent<EnemyDeath>();
        screenShake = Camera.main.GetComponent<ScreenShake>();
        currentEnemyHealth = maxEnemyHealth;
    }

    // Trigger MinionHealthDown if player bullet hits
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBullet")
        {
            MinionHealthDown();
        }
    }

    // Enemy health lost and screenshake
    public void MinionHealthDown()
    {
        screenShake.Shake(0.05f, -20f);
        currentEnemyHealth -= 1f;
        

        if (currentEnemyHealth <= 0f)
        {
            enemyDeath.DeathRoutine();
            Destroy(this.gameObject);
        }
        enemyDeath.OnHitAudio();
    }
}
