using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Collider collider;

    public KinematicCharacterMotor player;
    public Collider playerCollider;
    public Transform teleportTarget;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    void FixedUpdate()
    {
        if(collider.bounds.Intersects(playerCollider.bounds))
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 localPlayerPosition = transform.InverseTransformPoint(playerPosition);
            Quaternion deltaRotation = teleportTarget.rotation * Quaternion.Inverse(transform.rotation);
            var targetPosition = teleportTarget.TransformPoint(localPlayerPosition);
            Debug.Log($"Teleporting player from {playerPosition} to {targetPosition}");
            player.SetPosition(targetPosition);
            player.SetRotation(deltaRotation * player.transform.rotation);
        }
    }
}
