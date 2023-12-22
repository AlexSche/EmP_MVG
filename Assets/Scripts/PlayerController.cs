using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private EmPControls _controls;
    private CharacterController _characterController;
    public Transform cameraTransform;
    public float gravity = -9.81f;
    private float _yVelocity;
    public float terminalVelocity = -10f;
    public float jumpForce = 5f;
    public float mouseSensitivity = 0.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Create a control scheme instance and register listeners
        _controls = new EmPControls();
        _controls.Enable();
        _controls.Ingame.Camera.performed += OnCameraMove;
        _controls.Ingame.Jump.performed += OnJump;
        _characterController = GetComponent<CharacterController>();
        //Hide and lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Read current movement input (already normalized) and transform it to world space
        Vector2 movement = _controls.Ingame.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = transform.TransformDirection(move);
        
        //Move the character controller horizontally accounting for Time.deltaTime
        _characterController.Move(move * (Time.deltaTime * 5));
        
        //Apply gravity to vertical velocity if character is not grounded
        if(!_characterController.isGrounded)
            _yVelocity += gravity * Time.deltaTime;
        
        //Clamp to terminal velocity
        if (_yVelocity < terminalVelocity)
            _yVelocity = terminalVelocity;

        //Reset vertical velocity when grounded
        if (_yVelocity < 0 && _characterController.isGrounded)
            _yVelocity = 0;
        
        //Apply vertical velocity to character controller accounting for Time.deltaTime
        _characterController.Move(new Vector3(0, _yVelocity, 0) * Time.deltaTime);
    }

    //Every frame while the mouse is moved
    void OnCameraMove(InputAction.CallbackContext context)
    {
        //Get Mouse movement (already accounts for Time.deltaTime)
        Vector2 cameraMovement = context.ReadValue<Vector2>();
        
        //Rotate the entire player object on the y axis and the camera on the x axis
        transform.Rotate(Vector3.up, cameraMovement.x * mouseSensitivity);
        cameraTransform.Rotate(Vector3.right, -cameraMovement.y * mouseSensitivity);
        
        //Clamp the camera rotation so it can't go upside down
        cameraTransform.localEulerAngles = new Vector3(cameraTransform.localEulerAngles.x, 0, 0);
    }
    
    //Whenever jump is pressed
    void OnJump(InputAction.CallbackContext context)
    {
        //This should only allow jumping when the character is grounded but doesn't work 100% of the time for some reason
        if (_characterController.isGrounded)
        {
            _yVelocity = jumpForce;
        }
    }
    
}
