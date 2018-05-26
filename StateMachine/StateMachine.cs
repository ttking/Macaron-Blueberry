using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemachine : MonoBehaviour
{
    private IState currentlyRunningState;
    private IState PreviousState;

    public void ChangeState(IState newState)
    {
        if (this.currentlyRunningState != null)
        {
            this.currentlyRunningState.Exit();
        }

        this.PreviousState = this.currentlyRunningState;

        this.currentlyRunningState = newState;
        this.currentlyRunningState.Enter();
    }

    public void ExecuteStateUpdate()
    {
       var runningState = this.currentlyRunningState;
        if (runningState != null)
            runningState.Execute();
    }

    public void SwitchToPreviousState()
    {
        this.currentlyRunningState.Exit();
        this.currentlyRunningState = this.PreviousState;
        this.currentlyRunningState.Enter();
    }
}
