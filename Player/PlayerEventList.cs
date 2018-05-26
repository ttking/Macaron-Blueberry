using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class PlayerEventList : MonoBehaviour
{

    private IMoveable moveAble;
    private PlayerInputManager inputManager;
    private PlayerLives playerLives;
    private PlayerShooting playerShooting;
    private UpdateHearts updateHearts;

    //Get all necesary components
    private void Start()
    {
        moveAble = gameObject.GetComponent<PlayerMovement>();
        inputManager = GetComponent<PlayerInputManager>();
        playerLives = gameObject.GetComponent<PlayerLives>();
        playerShooting = gameObject.GetComponent<PlayerShooting>();
        updateHearts = gameObject.GetComponent<UpdateHearts>();
    }

    // Check for any of these Events
    void OnEnable()
    {
        EventManager.StartListening("MoveUp", MoveUpTrigger);
        EventManager.StartListening("MoveDown", MoveDownTrigger);
        EventManager.StartListening("MoveLeft", MoveLeftTrigger);
        EventManager.StartListening("MoveRight", MoveRightTrigger);
        /*
        //StopMovement event checker
        EventManager.StartListening("StopMoveUp", StopMoveUpTrigger);
        EventManager.StartListening("StopMoveDown", StopMoveDownTrigger);
        EventManager.StartListening("StopMoveLeft", StopMoveLeftTrigger);
        EventManager.StartListening("StopMoveRight", StopMoveRightTrigger);

        //Extra movement effects
        EventManager.StartListening("HalfSpeed", HalfSpeedTrigger);

        //Stop extra movement effects
        EventManager.StartListening("NormalSpeed", NormalSpeedTrigger);
        */
        //Player start shooting
        EventManager.StartListening("Shooting", ShootingTrigger);
        EventManager.StartListening("ShootingSecondary", ShootingSecondaryTrigger);

        //Player stop shooting
        EventManager.StartListening("StopShooting", StopShootingTrigger);
        EventManager.StartListening("StopShootingSecondary", StopShootingSecondaryTrigger);

        //Player health
        EventManager.StartListening("LivesDown", LivesDownTrigger);
        EventManager.StartListening("LiveLostAnimation", LiveAnimationTrigger);
    }

    // Disable these events in case an object gets destroyed ( Else memory leak is possible )
    void OnDisable()
    {
        EventManager.StopListening("MoveUp", MoveUpTrigger);
        EventManager.StopListening("MoveDown", MoveDownTrigger);
        EventManager.StopListening("MoveLeft", MoveLeftTrigger);
        EventManager.StopListening("MoveRight", MoveRightTrigger);

        /* StopMovement event check disabler
        EventManager.StopListening("StopMoveUp", StopMoveUpTrigger);
        EventManager.StopListening("StopMoveDown", StopMoveDownTrigger);
        EventManager.StopListening("StopMoveLeft", StopMoveLeftTrigger);
        EventManager.StopListening("StopMoveRight", StopMoveRightTrigger);

        // Extra movement effects
        EventManager.StopListening("HalfSpeed", HalfSpeedTrigger);

        // Stop extra movement effects
        EventManager.StopListening("NormalSpeed", NormalSpeedTrigger);
        */

        //Player start shooting
        EventManager.StopListening("Shooting", ShootingTrigger);
        EventManager.StopListening("ShootingSecondary", ShootingSecondaryTrigger);

        //Player stop shooting
        EventManager.StopListening("StopShooting", StopShootingTrigger);
        EventManager.StopListening("StopShootingSecondary", StopShootingSecondaryTrigger);

        //Player health
        EventManager.StopListening("LivesDown", LivesDownTrigger);
        EventManager.StopListening("LiveLostAnimation", LiveAnimationTrigger);
    }

    // Event Triggers

    //Movement start triggers
    void MoveUpTrigger()
    {
        moveAble.MoveUp(Input.GetKey(inputManager.up));
    }

    void MoveDownTrigger()
    {
        moveAble.MoveDown(Input.GetKey(inputManager.down));
    }

    void MoveLeftTrigger()
    {
        moveAble.MoveLeft(Input.GetKey(inputManager.left));
    }

    void MoveRightTrigger()
    {
        moveAble.MoveRight(Input.GetKey(inputManager.right));
    }

    // Extra movement effects trigger

    /*void HalfSpeedTrigger()
    {
        playerMovement.HalfSpeed();
    }

    // Stop extra movement trigger
    void NormalSpeedTrigger()
    {
        playerMovement.NormalSpeed();
    }*/

    // Start shooting trigger
    void ShootingTrigger()
    {
        playerShooting.Shooting();
    }

    void ShootingSecondaryTrigger()
    {
        playerShooting.ShootingSecondary();
    }

    //Stop shooting trigger
    void StopShootingTrigger()
    {
        playerShooting.StopShooting();
    }

    void StopShootingSecondaryTrigger()
    {
        playerShooting.StopShootingSecondary();
    }

    // Player health
    void LivesDownTrigger()
    {
        playerLives.LivesDown();
    }

    void LiveAnimationTrigger()
    {
        updateHearts.LiveLost();
    }

}