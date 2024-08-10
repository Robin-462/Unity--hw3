using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    private ParticleSystem[] ExplosionEffects;

    void Start()
    {
        ExplosionEffects = GetComponentsInChildren<ParticleSystem>();

        Collider barrelCollider = GetComponent<Collider>();
        if (barrelCollider != null)
        {
            barrelCollider.isTrigger = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Pistol Bullet"))
        {
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

            Destroy(gameObject, 0.1f);
        }
    }
}
