using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Weapon SFX")]
    [SerializeField] AudioClip laserSFX;
    [SerializeField] [Range(0f, 1f)] float laserVolume = 1f;

    [Header("Explosion SFX")]
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 0.5f;
    
    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }

    public void PlayLaserSFX()
    {
        PlayClip(laserSFX, laserVolume);
    }

    public void PlayExplosionSFX()
    {
        PlayClip(explosionSFX, explosionVolume);
    }
}
