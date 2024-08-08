using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    public ParticleSystem explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "barrel 11")
        {
            if (!explosion.isPlaying)
            {
                explosion.Play();
            }
        }
    }

    void Update()
    {
        if (explosion.isPlaying)
        {
            if (!IsCollidingWithBarrel11())
            {
                explosion.Stop();
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