using UnityEngine;

public class PistolController : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float lastShotTime;

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

            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            if (bulletComponent != null)
            {
                bulletComponent.SetLifeTime(5f);
            }
        }
        else
        {
            Debug.LogError("Muzzle not found on the object!");
        }
    }
}

public class Bullet : MonoBehaviour
{
    private float lifeTime;

    public void SetLifeTime(float time)
    {
        lifeTime = time;
        Invoke("DestroyBullet", lifeTime);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
