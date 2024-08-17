using UnityEngine;
using System.Collections;

public class LightningStrike : MonoBehaviour
{
    public float strikeIntervalMin = 5f;
    public float strikeIntervalMax = 15f;
    public float strikeDuration = 0.1f;
    public Vector3 cloudHeight = new Vector3(0, 80, 0);

    private float timer;
    private bool isStriking;

    void Start()
    {
        timer = Random.Range(strikeIntervalMin, strikeIntervalMax);
        transform.position = cloudHeight;
        transform.localScale = new Vector3(0.2f, 10f, 0.2f);
        gameObject.SetActive(false);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !isStriking)
        {
            StartCoroutine(StrikeLightning());
            timer = Random.Range(strikeIntervalMin, strikeIntervalMax);
        }
    }

    private IEnumerator StrikeLightning()
    {
        isStriking = true;
        gameObject.SetActive(true);
        yield return new WaitForSeconds(strikeDuration);
        gameObject.SetActive(false);
        isStriking = false;
    }
}
