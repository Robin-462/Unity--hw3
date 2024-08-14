using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip defaultMusic;
    public AudioClip fightMusic;
    public AudioClip suspenseMusic;

    private AudioSource audioSource;
    private bool isInSupplyStore = false;
    private bool hasSwitchedToFightMusic = false;  // 新增：用于标记是否已经切换到 fightMusic

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
            if (!hasSwitchedToFightMusic)  // 只有在未切换过的情况下才切换
            {
                SwitchToFightMusic();
                hasSwitchedToFightMusic = true;  // 切换后标记为已切换
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