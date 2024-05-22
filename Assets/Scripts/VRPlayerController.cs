using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class VRPlayerController : PlayerController
{
    private EmPControls _controls;
    public Transform trackedCamera;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start(); 
    }

    protected override void SetupControls()
    {
        //Create a control scheme instance and register listeners
        _controls = new EmPControls();
        _controls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Every frame while the mouse is moved
    void OnCameraMove(InputAction.CallbackContext context)
    {
        
    }
    
    //Whenever jump is pressed
    void OnJump(InputAction.CallbackContext context)
    {
    }

    public override void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {

    }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        //Read current movement input (already normalized) and transform it to world space
        Vector2 movement = _controls.VRLeftController.Move.ReadValue<Vector2>();

        //Apply gravity to vertical velocity if character is not grounded
        if(!_characterMotor.GroundingStatus.IsStableOnGround)
            _yVelocity += gravity * deltaTime;
        
        //Clamp to terminal velocity
        if (_yVelocity < terminalVelocity)
            _yVelocity = terminalVelocity;

        //Reset vertical velocity when grounded
        if (_yVelocity < 0 && _characterMotor.GroundingStatus.IsStableOnGround)
            _yVelocity = 0;

        Vector3 localCameraRotation = trackedCamera.localEulerAngles;
        Quaternion yAxis = Quaternion.Euler(new Vector3(0, localCameraRotation.y, 0));
        Vector3 rotatedMovement = new Vector3(movement.x, 0, movement.y);
        rotatedMovement = yAxis * rotatedMovement;
        currentVelocity = transform.TransformDirection(new Vector3(rotatedMovement.x, _yVelocity, rotatedMovement.z)*5);
    }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        return !coll.isTrigger;
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
        ref HitStabilityReport hitStabilityReport)
    {
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition,
        Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
    }
}
