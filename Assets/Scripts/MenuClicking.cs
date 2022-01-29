using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClicking : MonoBehaviour
{
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void PlayClickSFX()
    {
        audioPlayer.PlayUpgradeSFX();
    }
}
