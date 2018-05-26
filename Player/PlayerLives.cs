using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    private float timer;
    private float invincibilityLength = 5f;
    public float currentLives = 3f;

    private UpdateHearts updateHearts;

    //gets component
    private void Start()
    {
        updateHearts = GetComponent<UpdateHearts>();
    }

    //lose a life and get invincibility
    public void LivesDown()
    {
        if (timer <= Time.time)
        {
            currentLives -= 1;

            EventManager.TriggerEvent("LiveLostAnimation");
            timer = Time.time + invincibilityLength;
        }
        // destroy character object
        if (currentLives == 0)
        {
            
            Destroy(this.gameObject);
            
        }
    }
}
