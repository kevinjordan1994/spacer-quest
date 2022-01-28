using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float projectileFireRate = 0.5f;
    
    [Header("AI")]
    [SerializeField] bool usingAI;
    [SerializeField] float projectileFireRateVariation = 0.5f;
    [SerializeField] float minimumProjectileFireRate = 0.5f;

    [HideInInspector] public bool isFiring;

    Coroutine fireCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (usingAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            //Create the project
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            
            //Set its speed
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            
            //Destroy it after 5 seconds and repeat after the fire rate time has passed
            Destroy(instance, projectileLifeTime);

            //Play the laser SFX
            audioPlayer.PlayLaserSFX();
            yield return new WaitForSeconds(SetRandomFiringRate());
        }
    }

    float SetRandomFiringRate()
    {
        if (usingAI)
        {
            float fireRate = UnityEngine.Random.Range(projectileFireRate - projectileFireRateVariation, 
                projectileFireRate + projectileFireRateVariation);

            return Mathf.Clamp(fireRate, minimumProjectileFireRate, float.MaxValue);
        }
        else
        {
            return projectileFireRate;
        }
    }

    public float GetProjectileSpeed()
    {
        return projectileSpeed;
    }
}
