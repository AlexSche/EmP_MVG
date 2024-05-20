using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleporter : MonoBehaviour
{
    public Collider collider;
    public Transform player;
    public Collider playerCollider;
    public Transform teleportTarget;

    void FixedUpdate()
    {
        /* No VR-Teleport
        if(collider.bounds.Intersects(playerCollider.bounds))
        {
            Physics.gravity = teleportTarget.transform.up * 9.8f;
            Vector3 playerPosition = player.transform.position;
            Vector3 localPlayerPosition = transform.InverseTransformPoint(playerPosition);
            Quaternion deltaRotation = teleportTarget.rotation * Quaternion.Inverse(transform.rotation);
            var targetPosition = teleportTarget.TransformPoint(localPlayerPosition);
            Debug.Log($"Teleporting player from {playerPosition} to {targetPosition}");
            player.position = targetPosition;
            player.rotation = deltaRotation * player.transform.rotation;
        }
        
        // Teleport with change of gravity
        if (collider.bounds.Intersects(playerCollider.bounds))
        {
            Physics.gravity = new Vector3(0, 0, -9.8f);
            Physics.gravity = teleportTarget.transform.up * 9.8f;
            Debug.Log(teleportTarget.transform.up + "new gravity: " + Physics.gravity);
            //Vector3 localPlayerPosition = transform.InverseTransformPoint(player.transform.position);
            //Quaternion deltaRotation = teleportTarget.rotation * Quaternion.Inverse(transform.rotation);
            //var targetPosition = teleportTarget.TransformPoint(localPlayerPosition);
            Debug.Log($"Teleporting player from {player.transform.position} to {teleportTarget.position}");
            player.position = teleportTarget.position;
            //player.rotation = deltaRotation * player.transform.rotation;
        }
        */

        if(collider.bounds.Intersects(playerCollider.bounds))
        {
            Physics.gravity = teleportTarget.transform.up * 9.8f;
            player.position = teleportTarget.position;
            player.rotation = teleportTarget.rotation;
        }
    }
}
