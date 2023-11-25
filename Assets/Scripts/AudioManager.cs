using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour { 

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip selectSound;
    [SerializeField] private AudioClip startSound;

    public void PlaySelectSound()
    {
        audioSource.PlayOneShot(selectSound);
    }

    public void PlayStartSound()
    {
        audioSource.PlayOneShot(startSound);
    }
}

