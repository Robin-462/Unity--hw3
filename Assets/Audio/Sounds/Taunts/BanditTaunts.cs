using UnityEngine;

public class BanditTaunts : MonoBehaviour
{
    public AudioClip[] taunts;
    public AudioSource audioSource;

    private float minTimeBetweenTaunts = 10f;
    private float maxTimeBetweenTaunts = 30f;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        StartCoroutine(PlayTaunts());
    }

    private System.Collections.IEnumerator PlayTaunts()
    {
        while (true)
        {
            if (taunts.Length > 0)
            {
                int randomIndex = Random.Range(0, taunts.Length);
                AudioClip selectedTaunt = taunts[randomIndex];
                audioSource.PlayOneShot(selectedTaunt);
            }
            float waitTime = Random.Range(minTimeBetweenTaunts, maxTimeBetweenTaunts);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
