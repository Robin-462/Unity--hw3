using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip backgroundMusic;  // 初始的背景音乐
    public AudioClip shootingMusic;  // 开枪时切换的音乐

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioSource.Stop();
            audioSource.clip = shootingMusic;
            audioSource.Play();
        }
    }
}