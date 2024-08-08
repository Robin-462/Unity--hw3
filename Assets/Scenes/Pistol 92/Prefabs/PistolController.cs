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
        Camera mainCamera = Camera.main;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Transform muzzle = transform.Find("Muzzle"); 
            if (muzzle!= null)
            {
                GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);

                Vector3 originalDirection = (hit.point - muzzle.position);
                Vector3 shootDirection = mainCamera.transform.forward;
                shootDirection.y = 0;
                shootDirection = shootDirection.normalized;

                bullet.GetComponent<Rigidbody>().velocity = shootDirection * 10f;

                bullet.transform.Rotate(new Vector3(0, 90f, 0));

                Bullet bulletComponent = bullet.GetComponent<Bullet>();
                if (bulletComponent!= null)
                {
                    bulletComponent.SetLifeTime(5f); 
                }
            }
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