using UnityEngine;

public class bandit : MonoBehaviour
{
    public int health = 100;
    public GameObject bloodSprayPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Pistol Bullet"))
        {
            TakeDamage(50);
            PlayBloodSpray(other.transform.position);
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void PlayBloodSpray(Vector3 position)
    {
        GameObject bloodSpray = Instantiate(bloodSprayPrefab, position, Quaternion.identity);
        bloodSpray.transform.SetParent(transform);
    }

    private void Die()
    {
        Debug.Log("bandit died!");
        Destroy(gameObject);
    }
}
