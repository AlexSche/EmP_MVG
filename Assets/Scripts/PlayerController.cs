using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using KinematicCharacterController;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour, ICharacterController
{
    private EmPControls _controls;
    protected KinematicCharacterMotor _characterMotor;
    public Transform cameraTransform;
    public UniversalRendererData urpData;
    public float gravity = -9.81f;
    protected float _yVelocity;
    protected float _cameraPitch;
    public float terminalVelocity = -10f;
    public float jumpForce = 5f;
    public float mouseSensitivity = 0.8f;

    protected Vector3 _initialLightDirection;
    protected Material _fsMat;
    protected int _lightDirectionID;
    protected int _fadeToBlackID;

    // Start is called before the first frame update
    public virtual void Start()
    {
        SetupControls();
        _characterMotor = GetComponent<KinematicCharacterMotor>();
        _characterMotor.CharacterController = this;
        //Hide and lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        ScriptableRendererFeature feature = urpData.rendererFeatures.Find(srf => srf.name.Equals("FSOutline"));
        if (feature is FullScreenPassRendererFeature fsp)
        {
            _fsMat = fsp.passMaterial;
            _lightDirectionID = Shader.PropertyToID("_LightDirection");
            _fadeToBlackID = Shader.PropertyToID("_fadeToBlack");
            _initialLightDirection = _fsMat.GetVector(_lightDirectionID);
        }
    }

    protected virtual void SetupControls()
    {
        //Create a control scheme instance and register listeners
        _controls = new EmPControls();
                _controls.Enable();
                _controls.Ingame.Camera.performed += OnCameraMove;
                _controls.Ingame.Jump.performed += OnJump;
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
        //This should only allow jumping when the character is grounded but doesn't work 100% of the time for some reason
        if (_characterMotor.GroundingStatus.IsStableOnGround)
        {
            _yVelocity = jumpForce;
        }
    }

    public virtual void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        //Get Mouse movement (already accounts for Time.deltaTime)
        Vector2 cameraMovement = _controls.Ingame.Camera.ReadValue<Vector2>();
        
        //Rotate the entire player object on the y axis and the camera on the x axis
        var cameraYawDelta = cameraMovement.x * mouseSensitivity;
        _cameraPitch -= cameraMovement.y * mouseSensitivity;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -90, 90);
        
        cameraTransform.localEulerAngles = new Vector3(_cameraPitch, 0, 0);
        Quaternion playerRotation = Quaternion.Euler(new Vector3(0, cameraYawDelta, 0));
        currentRotation = transform.rotation * playerRotation;

    }

    public virtual void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        //Read current movement input (already normalized) and transform it to world space
        Vector2 movement = _controls.Ingame.Move.ReadValue<Vector2>();

        //Apply gravity to vertical velocity if character is not grounded
        if(!_characterMotor.GroundingStatus.IsStableOnGround)
            _yVelocity += gravity * deltaTime;
        
        //Clamp to terminal velocity
        if (_yVelocity < terminalVelocity)
            _yVelocity = terminalVelocity;

        //Reset vertical velocity when grounded
        if (_yVelocity < 0 && _characterMotor.GroundingStatus.IsStableOnGround)
            _yVelocity = 0;
        
        currentVelocity = transform.TransformDirection(new Vector3(movement.x*0.5f, _yVelocity, movement.y*0.5f)*5);
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

    public void UpdateLightDirection(Vector3 direction)
    {
        _fsMat.SetVector(_lightDirectionID, direction);
    }

    public Vector3 GetLightDirection()
    {
        return _fsMat.GetVector(_lightDirectionID);
    }
}
