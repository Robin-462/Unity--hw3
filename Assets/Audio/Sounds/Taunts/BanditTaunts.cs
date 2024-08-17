using UnityEngine;

public class BanditTaunts : MonoBehaviour
{
    public AudioClip[] taunts;
    public AudioSource audioSource;
    public CutsceneManager cutsceneManager;

    private float minTimeBetweenTaunts;
    private float maxTimeBetweenTaunts;
    private int tauntCount;

    void Start()
    {
        minTimeBetweenTaunts = 10f;
        maxTimeBetweenTaunts = 30f;
        tauntCount = 0;

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.volume = 0.5f;
        }
    }

    void Update()
    {
        if (!cutsceneManager.isCutscenePlaying)
        {
            if (tauntCount < 3)
            {
                StartCoroutine(PlayTaunts());
            }
        }
    }

    private System.Collections.IEnumerator PlayTaunts()
    {
        if (taunts.Length > 0)
        {
            int randomIndex = Random.Range(0, taunts.Length);
            AudioClip selectedTaunt = taunts[randomIndex];
            audioSource.PlayOneShot(selectedTaunt);
            tauntCount++;

            float waitTime = Random.Range(minTimeBetweenTaunts, maxTimeBetweenTaunts);
            yield return new WaitForSeconds(waitTime);
        }
    }
}