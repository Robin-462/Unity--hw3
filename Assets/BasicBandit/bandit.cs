using UnityEngine;

public class bandit : MonoBehaviour
{
    public int health = 100;
    public GameObject BloodSprayFX;
    public CutsceneManager cutsceneManager;
    private Animator animator;
    private bool IsMoving = false;
    public AudioClip deathSound;
    public AudioClip footstepSound;

    private AudioSource audioSource;
    private float distanceToCamera;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        distanceToCamera = Vector3.Distance(Camera.main.transform.position, transform.position);

        IsMoving = true; 

        if (IsMoving && !cutsceneManager.isCutscenePlaying)
        {
            if (distanceToCamera <= 10f)
            {
                PlayFootstepSound();
            }
        }

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
        PlayDeathSound();
    }

    private void PlayFootstepSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = footstepSound;
            audioSource.Play();
        }
    }

    private void PlayDeathSound()
    {
        audioSource.clip = deathSound;
        audioSource.Play();
    }
}