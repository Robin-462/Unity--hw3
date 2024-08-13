using UnityEngine;

public class bandit : MonoBehaviour
{
    public int health = 100;
    public GameObject BloodSprayFX;
    private Animator animator;
    private bool IsMoving = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsMoving)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("death1"))
            {

            }
        }
    }

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
            TriggerDeathAnimation();
        }
    }

    private void PlayBloodSpray(Vector3 position)
    {
        GameObject bloodSpray = Instantiate(BloodSprayFX, position, Quaternion.identity);
        bloodSpray.transform.SetParent(transform);
    }

    private void TriggerDeathAnimation()
    {
        animator.Play("death1");
        IsMoving = false;
        Destroy(BloodSprayFX);
    }
}