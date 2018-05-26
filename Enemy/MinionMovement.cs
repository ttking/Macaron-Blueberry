using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMovement : MonoBehaviour {
    [SerializeField]private AnimationCurve xCurve, yCurve, speedCurveX, speedCurveY, amplitudeCurve;
    private float speed = 2f;
    private float amplitude = 2f;
    private float angle = 0;
    private int radius = 5;
    private InternalTimer internalTimer;
    

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
        if (!internalTimer)
            internalTimer = GetComponent<InternalTimer>();
    }

    private void OnEnable()
    {
        if(!internalTimer)
            internalTimer = GetComponent<InternalTimer>();

        internalTimer.ResetInternalTime();
    }
    // Update is called once per frame 

    // Sets animatinon curve to adjust movement pattern
    public void Update () {

        transform.position = new Vector3(
                    startingPosition.x + (xCurve.Evaluate(internalTimer.currentInternalTime) * speedCurveX.Evaluate(internalTimer.currentInternalTime)),
                     startingPosition.y + (yCurve.Evaluate(internalTimer.currentInternalTime) * speedCurveY.Evaluate(internalTimer.currentInternalTime)), 0) * amplitudeCurve.Evaluate(internalTimer.currentInternalTime);

    }
}

