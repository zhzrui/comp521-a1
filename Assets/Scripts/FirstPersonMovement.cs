using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private float mouseSens = 0.25f;

    [SerializeField] private float jumpHeight = 1f;

    private CharacterController controller;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private float verticalVelocity;
    private float cameraVerticalRotation;

    private bool jumpPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    // getting inputs
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpPressed = true;
        }
    }

    void Move()
    {
        // get wasd input
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        move = Vector3.ClampMagnitude(move, 1f); // diagonal movement was messed up: slow down diag movement speed

        if (controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        // jump
        if (jumpPressed && controller.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        jumpPressed = false;

        // add gravity for fall -> fail case
        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * moveSpeed;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    void Look()
    {
        // camera on mouse movement
        float mouseX = lookInput.x * mouseSens;
        float mouseY = lookInput.y * mouseSens;

        // l-r, u-d camera rotations
        transform.Rotate(0f, mouseX, 0f);
        cameraVerticalRotation -= mouseY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        playerCamera.localEulerAngles = new Vector3(cameraVerticalRotation, 0f, 0f);
    }


}
