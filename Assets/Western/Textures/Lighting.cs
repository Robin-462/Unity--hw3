using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour
{
    public float strikeDuration = 1f;
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

        timer = 10f;
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
            timer = 10f;
        }
    }

    private IEnumerator StrikeLightning()
    {
        isStriking = true;
        lightningParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        yield return null;
        lightningParticleSystem.Play();
        audioSource.Play();
        yield return new WaitForSeconds(strikeDuration);
        lightningParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        isStriking = false;
    }
}
