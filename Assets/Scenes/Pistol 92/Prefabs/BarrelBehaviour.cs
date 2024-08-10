using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    private ParticleSystem[] ExplosionEffects;

    void Start()
    {
        ExplosionEffects = GetComponentsInChildren<ParticleSystem>();

        if (ExplosionEffects != null)
        {
            if (ExplosionEffects.Length > 0)
            {
                Debug.Log("Explosion component found: true");
            }
        }

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

            if (ExplosionEffects != null)
            {
                if (ExplosionEffects.Length > 0)
                {
                    foreach (var effect in ExplosionEffects)
                    {
                        if (effect != null)
                        {
                            effect.Play();
                            effect.transform.parent = null;
                            Destroy(effect.gameObject, effect.main.duration);
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Explosion effect is missing!");
            }

            Destroy(gameObject, 0.1f);
        }
    }
}
