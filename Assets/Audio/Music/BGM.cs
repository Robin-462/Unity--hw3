using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip defaultMusic;
    public AudioClip fightMusic;
    public AudioClip suspenseMusic;
    public AudioClip windSound;
    public AudioClip rainSound;

    private AudioSource audioSource;
    private AudioSource windAudioSource;
    private AudioSource rainAudioSource;
    private bool isInSupplyStore = false;
    private bool hasSwitchedToFightMusic = false;
    public float rainVolume = 4f;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = defaultMusic;
        audioSource.loop = true;
        audioSource.Play();
        windAudioSource = gameObject.AddComponent<AudioSource>();
        windAudioSource.clip = windSound;
        windAudioSource.loop = true;
        windAudioSource.Play();
        rainAudioSource = gameObject.AddComponent<AudioSource>();
        rainAudioSource.clip = rainSound;
        rainAudioSource.loop = true;
        rainAudioSource.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!hasSwitchedToFightMusic)
            {
                SwitchToFightMusic();
                hasSwitchedToFightMusic = true;
            }
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
