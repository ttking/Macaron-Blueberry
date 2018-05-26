using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventList : MonoBehaviour {

    [SerializeField] private LevelComplete levelComplete;


    private void Start()
    {

    }

    // Checks for level won event
    void OnEnable()
    {
        EventManager.StartListening("LevelWon", LevelWonTrigger);
      
    }

    // Disable these events in case an object gets destroyed ( Else memory leak is possible )
    void OnDisable()
    {
        EventManager.StopListening("LevelWon", LevelWonTrigger);
       
    }

    // Triggers level won
    void LevelWonTrigger()
    {
        levelComplete.LevelWon();
    }
}
