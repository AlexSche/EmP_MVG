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
    private Stopwatch timeOverall = new Stopwatch();
    private int doorsPassed = 0;
    private Stopwatch timeSpentMoving = new Stopwatch();
    private Stopwatch timeSpentStandingStill = new Stopwatch();
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
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
        timeSpentMoving.Start();
        UnityEngine.Debug.Log(timeSpentMoving.Elapsed);
    }

    public void stopTimeSpentMoving() {
        timeSpentMoving.Stop();
        UnityEngine.Debug.Log(timeSpentMoving.Elapsed);
    }

    public void startTimeSpentStandingStill() {
        timeSpentStandingStill.Start();
        UnityEngine.Debug.Log(timeSpentStandingStill.Elapsed);
    }

    public void stopTimeSpentStandingStill() {
        timeSpentStandingStill.Stop();
        UnityEngine.Debug.Log(timeSpentStandingStill.Elapsed);
    }

    public void doorPassed() {
        doorsPassed++;
    }
}
