using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour
{
    public float strikeIntervalMin = 30f;
    public float strikeIntervalMax = 60f;
    public float strikeDuration = 0.1f;
    public Vector3 cloudHeight = new Vector3(51, 73, 58);
    public AudioClip lightningSound;

    private float timer;
    private bool isStriking;
    private ParticleSystem lightningParticleSystem;
    private AudioSource audioSource;

    void Start()
    {
        lightningParticleSystem = GetComponent<ParticleSystem>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = lightningSound;
        timer = Random.Range(strikeIntervalMin, strikeIntervalMax);
        transform.position = cloudHeight;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (!isStriking)
            {
                StartCoroutine(StrikeLightning());
            }
            timer = Random.Range(strikeIntervalMin, strikeIntervalMax);
        }
    }

    private IEnumerator StrikeLightning()
    {
        isStriking = true;
        lightningParticleSystem.Play();
        audioSource.Play();
        yield return new WaitForSeconds(strikeDuration);
        lightningParticleSystem.Stop();
        isStriking = false;
    }
}
