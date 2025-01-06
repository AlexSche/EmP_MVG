using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int sceneIndex;
    public Collider triggerCollider;
    private Collider playerCollider;
    private EvaluationData evaluationData;
    void Start()
    {
        var _playerController = FindFirstObjectByType<PlayerController>(FindObjectsInactive.Include);
        playerCollider = _playerController.GetComponent<Collider>();
        evaluationData = GameObject.Find("EvaluationData").GetComponent<EvaluationData>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
            evaluationData.saveEvaluationData("_zwischenspeicher" + Guid.NewGuid().ToString());
        }
    }

    void FixedUpdate()
    {
        if (triggerCollider.bounds.Intersects(playerCollider.bounds))
        {
            SceneManager.LoadScene(sceneIndex);
            evaluationData.saveEvaluationData("_zwischenspeicher" + Guid.NewGuid().ToString());
        }
    }

}
