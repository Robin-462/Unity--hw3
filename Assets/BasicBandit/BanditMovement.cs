using UnityEngine;

public class BanditMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minSpeedForWalk = 1f; 
    private Transform cameraTransform;
    private Animator animator;
    private bool isMoving;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("death1"))
        {
            Vector3 direction = cameraTransform.position - transform.position;
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * moveSpeed);

            float currentSpeed = direction.magnitude;
            isMoving = currentSpeed > 0;

            if (currentSpeed >= minSpeedForWalk)
            {
                animator.SetBool("IsMoving", true);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }

            if (isMoving)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            isMoving = false;
            transform.position = transform.position;
            transform.rotation = transform.rotation;
        }
    }
}