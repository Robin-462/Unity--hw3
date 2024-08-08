using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    private ParticleSystem explosionEffect;

    void Start()
    {
        explosionEffect = GetComponentInChildren<ParticleSystem>();
        Debug.Log("Explosion component found: " + (explosionEffect != null));

        Collider barrelCollider = GetComponent<Collider>();
        if (barrelCollider != null)
        {
            barrelCollider.isTrigger = true;
            Debug.Log("Barrel Collider is present and set as Trigger.");
        }
        else
        {
            Debug.LogError("No Collider found on the barrel.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter method called");
        Debug.Log("Collision with: " + other.gameObject.name);
        if (other.gameObject.name.Contains("Pistol Bullet"))
        {
            Debug.Log("Pistol Bullet hit the barrel!");

            if (explosionEffect != null)
            {
                explosionEffect.Play();
                explosionEffect.transform.parent = null;
                Destroy(gameObject, 0.1f);
                Destroy(explosionEffect.gameObject, explosionEffect.main.duration);
            }
            else
            {
                Debug.LogError("Explosion effect is missing!");
            }
        }
    }
}
