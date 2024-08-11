using UnityEngine;

public class Bandit : MonoBehaviour
{
    public GameObject bloodSprayPrefab;
    private int bulletHits = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Pistol Bullet"))
        {
            bulletHits++;
            PlayBloodSpray(other.transform.position);
            Destroy(other.gameObject);
            if (bulletHits == 2)
            {
                Die();
            }
        }
    }

    private void PlayBloodSpray(Vector3 position)
    {
        Instantiate(bloodSprayPrefab, position, Quaternion.identity);
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Bandit died!");
    }
}