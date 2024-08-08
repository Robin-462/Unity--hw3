using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    public ParticleSystem Explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "barrel 11")
        {
            if (!Explosion.isPlaying)
            {
                Explosion.Play();
            }
        }
    }

    void Update()
    {
        if (Explosion.isPlaying)
        {
            if (!IsCollidingWithBarrel11())
            {
                Explosion.Stop();
            }
        }
    }

    bool IsCollidingWithBarrel11()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f); 
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.name == "barrel 11")
            {
                return true;
            }
        }
        return false;
    }
}