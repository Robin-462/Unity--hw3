using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    private ParticleSystem[] explosionEffects;

    void Start()
    {
        explosionEffects = GetComponentsInChildren<ParticleSystem>();

        Collider barrelCollider = GetComponent<Collider>();
        if (barrelCollider!= null)
        {
            barrelCollider.isTrigger = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Pistol Bullet"))
        {
            if (explosionEffects == null)
            {
                Debug.LogError("ExplosionEffects is null!");
                return;
            }
            if (explosionEffects.Length == 0)
            {
                Debug.LogError("No explosion effects found!");
                return;
            }

            foreach (var effect in explosionEffects)
            {
                if (effect!= null)
                {
                    effect.Play();
                    effect.transform.parent = null;
                    Destroy(effect.gameObject, effect.main.duration);
                }
                else
                {
                    Debug.LogWarning("Null effect found in the array.");
                }
            }

            Destroy(other.gameObject);
            Destroy(gameObject, 0.1f);
        }
    }
}