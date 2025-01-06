using System;
using TMPro;
using UnityEngine;

public class EvaluationToUI : MonoBehaviour
{
    private TMP_Text tmpObject;
    private EvaluationData evaluationData;
    void Start()
    {
        evaluationData = GameObject.Find("EvaluationData").GetComponent<EvaluationData>();
        tmpObject = GetComponent<TMP_Text>();
        evaluationData.stopAllTimer();
        evaluationData.saveEvaluationData(Guid.NewGuid().ToString());
        tmpObject.text = createEvaluationText();    
    }

    public string createEvaluationText() {
        return "Gesamtzeit: " + evaluationData.timeOverallInSeconds + " Sekunden." + "\n"
            + "Still gestanden: " + evaluationData.timeSpentStandingStillInSeconds + " Sekunden." + "\n" 
            + "In Bewegung: " + evaluationData.timeSpentMovingInSeconds + " Sekunden." + "\n" 
            + "Benutzte Durchgänge: " + evaluationData.doorsPassed;
    }
}
