using UnityEngine;

public class CowboyController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform pistolTransform;
    public Transform cameraTransform;

    private Animator animator;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("front_kick");
        }
    }

    void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        bool isMoving = false;

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
        if (isMoving)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            {
                animator.CrossFade("walk", 0); 
            }
            moveDirection.Normalize();
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
        }
        else
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                animator.CrossFade("idle", 0); 
            }
        }
    }
}