using UnityEngine;

public class CowboyController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform pistolTransform;
    public Transform cameraTransform;

    private Animator animator;
    private bool isMoving;
    private float animationBlendTime = 0.2f;

    void Start()
    {
        if (cameraTransform == null || pistolTransform == null)
        {
            Debug.LogError("CameraTransform or PistolTransform is not assigned.");
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;

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
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
            isMoving = true;
        }

        moveDirection.y = 0f;

        if (moveDirection!= Vector3.zero)
        {
            moveDirection.Normalize();
            transform.position += moveDirection * movementSpeed * Time.deltaTime;

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                animator.CrossFade("walk", animationBlendTime);
            }
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            {
                animator.CrossFade("idle", animationBlendTime);
            }
            isMoving = false;
        }
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up, mouseX);
    }
}