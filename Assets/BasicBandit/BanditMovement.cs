using UnityEngine;

public class BanditMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector3 direction = cameraTransform.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * moveSpeed);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
