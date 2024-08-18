using UnityEngine;

public class CowboyController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform pistolTransform;
    public Transform cameraTransform;

    private Animator animator;
    private bool isMoving;

    private float rotationY = 0f;

    void Start()
    {
        if (cameraTransform == null || pistolTransform == null)
        {
            Debug.LogError("CameraTransform or PistolTransform is not assigned.");
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;

        // 初始化摄像头的旋转，使其与角色保持一致
        rotationY = transform.eulerAngles.y;
        cameraTransform.rotation = Quaternion.Euler(0f, rotationY, 0f);

        // 确保摄像头的Z轴没有旋转（防止上下颠倒）
        cameraTransform.localRotation = Quaternion.Euler(cameraTransform.localEulerAngles.x, cameraTransform.localEulerAngles.y, 0f);

        animator = GetComponent<Animator>();
        animator.Play("idle");
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("front_kick");
        }
    }

    void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }

        isMoving = moveDirection != Vector3.zero;

        if (isMoving)
        {
            animator.Play("walk");
            moveDirection.Normalize();
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
        }
        else
        {
            animator.Play("idle");
        }
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

        // 同步摄像头的Y轴旋转，并保持Z轴为0（避免反转）
        cameraTransform.rotation = Quaternion.Euler(cameraTransform.localEulerAngles.x, rotationY, 0f);
    }
}
