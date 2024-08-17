using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robortmove : MonoBehaviour
{
    public float speed = 3f;
    public float raycastHeight = 1f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(x, 0, z).normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.LookAt(transform.position + moveDirection);

            Vector3 horizontalMove = moveDirection * speed * Time.deltaTime;
            Vector3 targetPosition = transform.position + horizontalMove;

            RaycastHit hit;
            if (Physics.Raycast(targetPosition + Vector3.up * raycastHeight, Vector3.down, out hit))
            {
                targetPosition.y = hit.point.y;
            }

            transform.position = targetPosition;

            animator.speed = 1f;
        }
        else
        {
            animator.speed = 0f;
        }
    }
}
