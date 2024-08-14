using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip defaultMusic;
    public AudioClip fightMusic;
    public AudioClip suspenseMusic;

    private AudioSource audioSource;
    private bool isInSupplyStore = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = defaultMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchToFightMusic();
        }

        if (IsNearSupplyStore())
        {
            if (!isInSupplyStore)
            {
                SwitchToSuspenseMusic();
                isInSupplyStore = true;
            }
        }
        else
        {
            if (isInSupplyStore)
            {
                SwitchToDefaultMusic();
                isInSupplyStore = false;
            }
        }
    }

    private void SwitchToDefaultMusic()
    {
        audioSource.Stop();
        audioSource.clip = defaultMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void SwitchToFightMusic()
    {
        audioSource.Stop();
        audioSource.clip = fightMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void SwitchToSuspenseMusic()
    {
        audioSource.Stop();
        audioSource.clip = suspenseMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    private bool IsNearSupplyStore()
    {
        Collider[] colliders = Physics.OverlapSphere(Camera.main.transform.position, 5f);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("SupplyStore"))
            {
                return true;
            }
        }
        return false;
    }
}