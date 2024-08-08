using UnityEngine;

public class BarrelTriggerScript : MonoBehaviour
{
    private ParticleSystem fire;
    private bool isCollidedWithBullet = false;

    private void Start()
    {
        fire = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pistol Bullet")
        {
            isCollidedWithBullet = true;
        }
    }

    private void Update()
    {
        if (isCollidedWithBullet)
        {
            fire.Play();
            isCollidedWithBullet = false;
        }
    }
}