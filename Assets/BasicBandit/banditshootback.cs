using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banditshootback : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform pistol92Transform;
    public float minShootInterval = 30f;
    public float maxShootInterval = 60f;
    public float bulletSpeed = 10f;
    public float minAngle = -5f;
    public float maxAngle = 5f;
    public AudioClip injuriedSound;

    private Transform playerTransform;
    private float nextShootTime;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        ScheduleNextShot();
    }

    void Update()
    {
        if (Time.time >= nextShootTime)
        {
            ShootAtPlayer();
            ScheduleNextShot();
        }
    }

    void ShootAtPlayer()
    {
        if (playerTransform == null || bulletPrefab == null)
            return;

        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        Vector3 shootDirection = Quaternion.Euler(0f, Random.Range(minAngle, maxAngle), 0f) * directionToPlayer;

        transform.rotation = Quaternion.LookRotation(shootDirection);

        GameObject bullet = Instantiate(bulletPrefab, pistol92Transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;

        RaycastHit hit;
        if (Physics.Raycast(pistol92Transform.position, shootDirection, out hit))
        {
            if (hit.transform == playerTransform)
            {
                AudioSource.PlayClipAtPoint(injuriedSound, playerTransform.position);
                Debug.Log("Player hit!");
            }
        }
    }

    void ScheduleNextShot()
    {
        nextShootTime = Time.time + Random.Range(minShootInterval, maxShootInterval);
    }
}
