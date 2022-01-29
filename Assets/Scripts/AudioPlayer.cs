using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    [Header("Weapon SFX")]
    [SerializeField] AudioClip laserSFX;
    [SerializeField] [Range(0f, 1f)] float laserVolume = 1f;
    [SerializeField] AudioClip electricBeamSFX;
    [SerializeField] [Range(0f, 1f)] float electricVolume = 0.1f;

    [Header("Explosion SFX")]
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 0.5f;

    [Header("Misc SFX")]
    [SerializeField] AudioClip collectUpgrade;
    [SerializeField] [Range(0f, 1f)] float upgradeVolume = 0.5f;
    [SerializeField] AudioClip seekerGrowl;
    [SerializeField] [Range(0f, 1f)] float seekerVolume = 0.5f;

    static AudioPlayer audioPlayer;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(audioPlayer != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            audioPlayer = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        HandleMusic();
    }

    void HandleMusic()
    {
        if (ItsMenu())
        {
            transform.Find("MenuMusic").gameObject.SetActive(true);
            transform.Find("Level1Music").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("Level1Music").gameObject.SetActive(true);
            transform.Find("MenuMusic").gameObject.SetActive(false);
        }
    }

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

    public void PlayUpgradeSFX()
    {
        PlayClip(collectUpgrade, upgradeVolume);
    }

    public void PlaySeekerSFX()
    {
        PlayClip(seekerGrowl, seekerVolume);
    }

    public void PlayElectricBeamSFX()
    {
        PlayClip(electricBeamSFX, electricVolume);
    }

    bool ItsMenu()
    {
        return SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0) ||
            SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2);
    }
}
