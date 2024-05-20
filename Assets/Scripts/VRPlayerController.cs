using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class VRPlayerController : MonoBehaviour, ICharacterController
{
    private EmPControls _controls;
    private KinematicCharacterMotor _characterMotor;
    public float gravity = -9.81f;
    private float _yVelocity;
    private float _cameraPitch;
    public float terminalVelocity = -10f;
    public float jumpForce = 5f;
    public float mouseSensitivity = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        //Create a control scheme instance and register listeners
        _controls = new EmPControls();
        _controls.Enable();
        _characterMotor = GetComponent<KinematicCharacterMotor>();
        _characterMotor.CharacterController = this;
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

    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        //Get Mouse movement (already accounts for Time.deltaTime)
        Vector2 cameraMovement = _controls.Ingame.Camera.ReadValue<Vector2>();
        
        //Rotate the entire player object on the y axis and the camera on the x axis
        var cameraYawDelta = cameraMovement.x * mouseSensitivity;
        _cameraPitch -= cameraMovement.y * mouseSensitivity;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -90, 90);
        
        //cameraTransform.localEulerAngles = new Vector3(_cameraPitch, 0, 0);
        Quaternion playerRotation = Quaternion.Euler(new Vector3(0, cameraYawDelta, 0));
        currentRotation = transform.rotation * playerRotation;

    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
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
        
        currentVelocity = transform.TransformDirection(new Vector3(movement.x, _yVelocity, movement.y)*5);
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
    }

    public void PostGroundingUpdate(float deltaTime)
    {
    }

    public void AfterCharacterUpdate(float deltaTime)
    {
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
    
    float nfmod(float a,float b)
    {
        return a - b * Mathf.Floor(a / b);
    }
}
