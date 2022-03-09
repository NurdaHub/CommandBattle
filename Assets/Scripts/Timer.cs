using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float currentSec;
    private bool timerIsRunning;

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
            currentSec += Time.deltaTime;
    }

    public double GetTime()
    {
        timerIsRunning = false;
        var roundedSec = Math.Round(currentSec);
        
        return roundedSec;
    }
}
