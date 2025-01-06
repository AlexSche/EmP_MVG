using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class EvaluationData : MonoBehaviour
{
    public static EvaluationData Instance;
    // Daten die wir erfassen wollen verschiedene Zeiten, Anzahl Durchgänge
    // Wurden bestimmte Objekte länger angeschaut und haben bei der Orientierung geholfen?
    private Stopwatch timeOverall;
    private int doorsPassed = 0;
    private Stopwatch timeSpentMoving;
    private Stopwatch timeSpentStandingStill ;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        timeOverall = new Stopwatch();
        timeSpentMoving = new Stopwatch();
        timeSpentStandingStill = new Stopwatch();
        startTimeOverall();
    }


    public void startTimeOverall()
    {
        timeOverall.Start();
        UnityEngine.Debug.Log(timeOverall.Elapsed);
    }

    public void stopTimeOverall()
    {
        timeOverall.Stop();
        UnityEngine.Debug.Log(timeOverall.Elapsed);
    }

    public void startTimeSpentMoving() {
        timeSpentStandingStill.Stop();
        UnityEngine.Debug.Log(timeSpentStandingStill.Elapsed);
        timeSpentMoving.Start();
        UnityEngine.Debug.Log(timeSpentMoving.Elapsed);
    }

    public void stopTimeSpentMoving() {
        timeSpentStandingStill.Start();
        UnityEngine.Debug.Log(timeSpentStandingStill.Elapsed);
        timeSpentMoving.Stop();
        UnityEngine.Debug.Log(timeSpentMoving.Elapsed);
    }

    public void doorPassed() {
        doorsPassed++;
        UnityEngine.Debug.Log(doorsPassed);
    }
}
