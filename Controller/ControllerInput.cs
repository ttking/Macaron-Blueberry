using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Keyboard input
    void Update()
    {

        //GetKeyDown input
        if (Input.GetKey("up"))
        {
            
            EventManager.TriggerEvent("MoveUp");
        }

        if (Input.GetKey("down"))
        {
            
            EventManager.TriggerEvent("MoveDown");
        }

        if (Input.GetKey("left"))
        {
            
            EventManager.TriggerEvent("MoveLeft");
        }

        if (Input.GetKey("right"))
        {
           
            EventManager.TriggerEvent("MoveRight");
        }

        // Shooting / abilities GetKeyDown Input

        if (Input.GetKeyDown("x"))
        {
            //Debug.Log("Pew");
            EventManager.TriggerEvent("Shooting");
        }

        if (Input.GetKeyDown("c"))
        {
            EventManager.TriggerEvent("ShootingSecondary");
        }

        if (Input.GetKeyDown("left shift"))
        {
            EventManager.TriggerEvent("HalfSpeed");
        }

        //GetKeyUp Input
        if (Input.GetKeyUp("up"))
        {
            EventManager.TriggerEvent("StopMoveUp");
        }

        if (Input.GetKeyUp("down"))
        {
            EventManager.TriggerEvent("StopMoveDown");
        }

        if (Input.GetKeyUp("left"))
        {
            EventManager.TriggerEvent("StopMoveLeft");
        }

        if (Input.GetKeyUp("right"))
        {
            EventManager.TriggerEvent("StopMoveRight");
        }

        //Shooting / abilities GetKeyUp input

        if (Input.GetKeyUp("x"))
        {
            EventManager.TriggerEvent("StopShooting");
        }

        if (Input.GetKeyUp("c"))
        {
            EventManager.TriggerEvent("StopShootingSecondary");
        }

        if (Input.GetKeyUp("left shift"))
        {
            EventManager.TriggerEvent("NormalSpeed");
        }

        //User Interface input
        if (Input.GetKeyDown("p"))
        {
            EventManager.TriggerEvent("PauseGame");
        }

        if (Input.GetKeyDown("escape"))
        {
            EventManager.TriggerEvent("PauseGame");
        }


        //Xbox controller input 

        /* if (Input.GetKeyDown("0")){
             EventManager.TriggerEvent("");
         }

         if (Input.GetKeyDown("3")) {
             EventManager.TriggerEvent("");
         }

         if (Input.GetButtonDown("x axis" )){
             EventManager.TriggerEvent("");
         }

         if (Input.GetButtonDown("y axis")){
             EventManager.TriggerEvent("");
         }

         if (Input.GetKeyDown("7")){
             EventManager.TriggerEvent("");
         }

         if (Input.GetKeyDown("6"))        {
             EventManager.TriggerEvent("");
         }*/


    }
}
