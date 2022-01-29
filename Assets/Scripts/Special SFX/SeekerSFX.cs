using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerSFX : MonoBehaviour
{
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        audioPlayer.PlaySeekerSFX();
    }
}
