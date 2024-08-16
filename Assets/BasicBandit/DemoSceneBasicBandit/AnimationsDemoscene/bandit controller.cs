using UnityEngine;

public class BanditController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public Transform gunTransform;

    public float moveSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        GameObject banditObject = GameObject.Find("bandit 5");
        if (banditObject!= null)
        {
            transform.position = banditObject.transform.position;
            transform.rotation = banditObject.transform.rotation;
        }
        else
        {
            Debug.LogError("Object named 'bandit 5' not found!");
        }

        GameObject pistolObject = GameObject.Find("pistol 92");
        
        if (pistolObject!= null)
        {
            gunTransform = pistolObject.transform;
        }
        else
        {
            Debug.LogError("Object named 'pistol 92' not found!");
        }
    }

    void Update()
    {

        Vector3 directionToGun = (gunTransform.position - transform.position).normalized;
        Vector3 movement = directionToGun * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        bool isMoving = movement.magnitude > 0;
        animator.SetBool("IsWalking", isMoving);
    }
}