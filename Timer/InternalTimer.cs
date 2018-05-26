using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalTimer : MonoBehaviour {
    public float currentInternalTime;
    public float timerMultiplier = 1f;
	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        if(currentInternalTime != 0)
        ResetInternalTime();
    }

    // Update is called once per frame
    void Update () {
        UpdateInternalTimer();
	}

    private void UpdateInternalTimer()
    {
        currentInternalTime += Time.deltaTime * timerMultiplier;
    }

    public void ResetInternalTime()
    {
        currentInternalTime = 0;
    }
}
