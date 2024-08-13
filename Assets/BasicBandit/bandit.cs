using UnityEngine;

public class bandit : MonoBehaviour
{
    public int health = 100;
    public GameObject BloodSprayFX;
    private Animator animator;
    private Rigidbody rb;
    private bool IsMoving = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!IsMoving)
            return;
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

        // 停止所有移动
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Destroy(BloodSprayFX);
        IsMoving = false;

        // 禁用 Animator 组件
        animator.enabled = false;
    }
}
