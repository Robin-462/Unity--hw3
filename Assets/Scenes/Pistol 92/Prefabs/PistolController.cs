using UnityEngine;

public class PistolController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioClip pistolSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Vector3 shootDirection;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            shootDirection = (hit.point - mainCamera.transform.position).normalized;
        }
        else
        {
            shootDirection = mainCamera.transform.forward;
        }

        Transform muzzle = transform.Find("Muzzle");

        if (muzzle != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * 10f;
            bullet.transform.rotation = Quaternion.LookRotation(shootDirection);

            audioSource.PlayOneShot(pistolSound);
        }
        else
        {
            Debug.LogError("Muzzle not found on the object!");
        }
    }
}
