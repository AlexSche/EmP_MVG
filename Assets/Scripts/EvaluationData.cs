using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class EvaluationData : MonoBehaviour
{
    private string fileName = "evaluationDataMVG3.json";
    private SerializeEvaluation serializeEvaluation;
    public static EvaluationData Instance;
    // Daten die wir erfassen wollen verschiedene Zeiten, Anzahl Durchgänge
    // Wurden bestimmte Objekte länger angeschaut und haben bei der Orientierung geholfen?
    public Stopwatch timeOverall;
    public Stopwatch timeSpentMoving;
    public Stopwatch timeSpentStandingStill;
    public int doorsPassed = 0;
    public double timeOverallInSeconds = 0;
    public double timeSpentMovingInSeconds = 0;
    public double timeSpentStandingStillInSeconds = 0;
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
        UnityEngine.Debug.Log(Application.persistentDataPath);
        serializeEvaluation = new SerializeEvaluation(Application.persistentDataPath, fileName);
        startTimeOverall();
        fileName = fileName + DateTime.Now;
    }


    public void startTimeOverall()
    {
        timeOverall.Start();
    }

    public void stopTimeOverall()
    {
        timeOverall.Stop();
    }

    public void startTimeSpentMoving()
    {
        timeSpentStandingStill.Stop();
        timeSpentMoving.Start();
    }

    public void stopTimeSpentMoving()
    {
        timeSpentStandingStill.Start();
        timeSpentMoving.Stop();
    }

    public void doorPassed()
    {
        doorsPassed++;
        UnityEngine.Debug.Log(doorsPassed);
    }

    public void saveEvaluationData() {
        convertData();
        serializeEvaluation.Save(this);
    }

    private void convertData() {
        timeOverallInSeconds = timeOverall.Elapsed.TotalSeconds;
        timeSpentMovingInSeconds = timeSpentMoving.Elapsed.TotalSeconds;
        timeSpentStandingStillInSeconds = timeSpentStandingStill.Elapsed.TotalSeconds;
    }
}
