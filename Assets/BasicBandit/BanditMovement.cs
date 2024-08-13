using UnityEngine;

public class BanditMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minSpeedForWalk = 1f; 
    private Transform cameraTransform;
    private Animator anim;
    private bool isMoving;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 direction = cameraTransform.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * moveSpeed);

        float currentSpeed = direction.magnitude;
        isMoving = currentSpeed > 0;

        if (currentSpeed >= minSpeedForWalk)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

        if (isMoving)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}