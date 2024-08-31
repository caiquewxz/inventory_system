using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float mouseSensitivity = 100.0f;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float cameraPitch = 0.0f;
    [SerializeField] private float maxLookAngle = 85.0f;
    [SerializeField] private Animator animController;
    [SerializeField] private float animationSmoothFactor = 2;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private float currentSpeed;
    private float acceleration = 3f;
    private Vector3 oldDirection;

    private static PlayerMovement _instance;

    public static PlayerMovement instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<PlayerMovement>();
            }

            return _instance;
        }
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovement();
        if(!Inventory.Instance.isOpen)
            HandleCamera();

        UpdateAnimationParams();
    }

    void UpdateAnimationParams()
    {
        Vector3 velocityForward = controller.velocity;
        velocityForward.Scale(transform.forward);
        
        Vector3 velocityRight = controller.velocity;
        velocityRight.Scale(transform.right);

        float speedForward = velocityForward.x + velocityForward.z;
        float speedRight = velocityRight.x + velocityRight.z;

        animController.SetFloat("SpeedForward", speedForward);
        animController.SetFloat("SpeedRight", speedRight);
    }

    void HandleMovement()
    {
        if (controller.isGrounded)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            moveDirection = new Vector3(moveX, 0.0f, moveZ);
            moveDirection.Normalize();
            moveDirection = transform.TransformDirection(moveDirection);
            if (moveDirection.magnitude > 0)
            {
                currentSpeed += acceleration * Time.deltaTime;
                if (currentSpeed > speed) currentSpeed = speed;
            }
            else
            {
                currentSpeed -= acceleration * Time.deltaTime;
                if (currentSpeed < 0) currentSpeed = 0;
            }
            moveDirection *= currentSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 newDirection = Vector3.Lerp(oldDirection, moveDirection, animationSmoothFactor * Time.deltaTime);
        oldDirection = newDirection;
        controller.Move(newDirection * Time.deltaTime);
    }

    void HandleCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity * .7f) * Time.deltaTime;    

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * mouseX);
    }
}