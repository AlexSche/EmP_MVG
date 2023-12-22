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
        _controls = new EmPControls();
        _controls.Enable();
        _controls.Ingame.Camera.performed += OnCameraMove;
        _controls.Ingame.Jump.performed += OnJump;
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = _controls.Ingame.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = transform.TransformDirection(move);
        _characterController.Move(move * (Time.deltaTime * 5));
        _yVelocity += gravity * Time.deltaTime;
        if (_yVelocity < terminalVelocity)
        {
            _yVelocity = terminalVelocity;
        }

        if (_characterController.isGrounded && _yVelocity < 0)
        {
            _yVelocity = 0;
        }
        _characterController.Move(new Vector3(0, _yVelocity, 0) * Time.deltaTime);
    }

    void OnCameraMove(InputAction.CallbackContext context)
    {
        Vector2 cameraMovement = context.ReadValue<Vector2>();
        transform.Rotate(Vector3.up, cameraMovement.x * mouseSensitivity);
        cameraTransform.Rotate(Vector3.right, -cameraMovement.y * mouseSensitivity);
        cameraTransform.localEulerAngles = new Vector3(cameraTransform.localEulerAngles.x, 0, 0);
    }
    
    void OnJump(InputAction.CallbackContext context)
    {
        if (_characterController.isGrounded)
        {
            _yVelocity = jumpForce;
        }
    }
    
}
