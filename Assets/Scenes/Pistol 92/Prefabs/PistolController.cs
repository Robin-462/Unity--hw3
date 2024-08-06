using UnityEngine;

public class PistolController : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float lastShotTime;

    void Start()
    {
        lastShotTime = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time - lastShotTime >= 1f)
            {
                ShootBullet();
                lastShotTime = Time.time;
            }
        }
    }

    void ShootBullet()
{
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out RaycastHit hit))
    {
        Transform muzzle = transform.Find("Muzzle"); 
        if (muzzle!= null)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);

            Vector3 originalDirection = (hit.point - muzzle.position);
            Vector3 shootDirection = new Vector3(originalDirection.x, 0, originalDirection.z);
            shootDirection = -shootDirection.normalized;

            bullet.GetComponent<Rigidbody>().velocity = shootDirection * 10f;

            bullet.transform.Rotate(new Vector3(0, 90f, 0));
        }
    }
}
}