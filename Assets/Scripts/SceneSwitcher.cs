using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int sceneIndex;
    public Collider triggerCollider;
    private Collider playerCollider;
    void Start()
    {
        var _playerController = FindFirstObjectByType<PlayerController>(FindObjectsInactive.Include);
        playerCollider = _playerController.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
            Debug.Log("Loading next Scene");
        }
    }

    void FixedUpdate()
    {
        if (triggerCollider.bounds.Intersects(playerCollider.bounds))
        {
            SceneManager.LoadScene(sceneIndex);
            Debug.Log("Loading next Scene");
        }
    }

}
