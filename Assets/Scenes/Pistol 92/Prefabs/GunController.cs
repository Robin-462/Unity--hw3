using UnityEngine;

public class GunController : MonoBehaviour
{
    public float sensitivity = 2f;
    public Camera cameraToRotate;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationY += mouseX;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
        if (cameraToRotate != null)
        {
            cameraToRotate.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
    }
}
