using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerCollisionEventTriggers : MonoBehaviour
{
    //Trigger event on collision with certain tags      
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet")
        {
            EventManager.TriggerEvent("LivesDown");
        }
    }
}