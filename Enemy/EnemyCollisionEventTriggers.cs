using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionEventTriggers : MonoBehaviour {

    // Event list for collisions
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBullet")
        {
            EventManager.TriggerEvent("EnemyHealthDown");
        }
    }
}
