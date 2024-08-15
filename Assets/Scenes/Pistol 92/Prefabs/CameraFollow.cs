using UnityEngine;

public class GunCameraController : MonoBehaviour
{
    public float sensitivity = 300f; 
    public Transform cameraTransform; 
    public Transform gunTransform; 

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        cameraTransform.parent = gunTransform;
        cameraTransform.localPosition = Vector3.zero;


        cameraTransform.localRotation = gunTransform.localRotation;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        gunTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        cameraTransform.rotation = gunTransform.rotation;
    }
}