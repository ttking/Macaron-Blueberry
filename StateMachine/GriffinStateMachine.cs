using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffinStateMachine : Statemachine {

    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] Attack1 attack1;

    void Start() {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void StateSwitch ()
    {
        if(enemyHealth.currentEnemyHealth > 250)
        {
            attack1.Enter();
        }

        else
        {
            
        }
    
    }

}
