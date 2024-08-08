using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    private ParticleSystem Explosion;

    void Start()
    {
        Explosion = GetComponentInChildren<ParticleSystem>();
        Debug.Log("Explosion component found: " + (Explosion!= null));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pistol Bullet")
        {
            Explosion.Play();
            Destroy(gameObject);
        }
    }
}