using System;
using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Collider triggerCollider;

    private KinematicCharacterMotor _player;
    private Collider _playerCollider;
    public Transform teleportTarget;

    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindFirstObjectByType<PlayerController>(FindObjectsInactive.Include);
        _player = _playerController.GetComponent<KinematicCharacterMotor>();
        _playerCollider = _playerController.GetComponent<Collider>();
    }
    
    void FixedUpdate()
    {
        if(triggerCollider.bounds.Intersects(_playerCollider.bounds))
        {
            if (teleportTarget == null) return;
            Transform playerTransform = _player.transform;
            Vector3 localLightDir = playerTransform.InverseTransformDirection(_playerController.GetLightDirection());
            Vector3 playerPosition = playerTransform.position;
            Vector3 localPlayerPosition = transform.InverseTransformPoint(playerPosition);
            Quaternion deltaRotation = teleportTarget.rotation * Quaternion.Inverse(transform.rotation);
            var targetPosition = teleportTarget.TransformPoint(localPlayerPosition);
            Debug.Log($"Teleporting player from {playerPosition} to {targetPosition}");
            _player.SetPosition(targetPosition);
            _player.SetRotation(deltaRotation * _player.transform.rotation);
            _playerController.UpdateLightDirection(playerTransform.TransformDirection(localLightDir));
        }
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (teleportTarget == null) return;
        if (transform.parent == null) return;
        if (teleportTarget.transform.parent == null) return;
        bool thisSelected = UnityEditor.Selection.Contains(gameObject) ||
                            UnityEditor.Selection.Contains(transform.parent.gameObject);
        bool targetSelected = UnityEditor.Selection.Contains(teleportTarget.gameObject) ||
                              UnityEditor.Selection.Contains(teleportTarget.parent.gameObject);
        if (thisSelected == targetSelected) return;
        if(thisSelected)
            Gizmos.color = Color.blue;
        if(targetSelected)
            Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, teleportTarget.transform.position);
    }
    #endif
}
