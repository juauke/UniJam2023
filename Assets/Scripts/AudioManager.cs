using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour { 

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip selectSound;
    [SerializeField] private AudioClip startSound;
    [SerializeField] private AudioClip stepSound;
    [SerializeField] private AudioClip iceSound;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip takeSound;
    [SerializeField] private AudioClip dropSound;
    [SerializeField] private AudioClip climbLadderSound;
    [SerializeField] private AudioClip victorySound;
    [SerializeField] private AudioClip thunderSound;



    public void PlaySelectSound()
    {
        audioSource.PlayOneShot(selectSound);
    }

    public void PlayStartSound()
    {
        audioSource.PlayOneShot(startSound);
    }

    public void PlayIceSound()
    {
        audioSource.PlayOneShot(iceSound);
    }

    public void PlayFireSound()
    {
        audioSource.PlayOneShot(fireSound);
    }

    public void PlayTakeSound()
    {
        audioSource.PlayOneShot(takeSound);
    }

    public void PlayDropSound()
    {
        audioSource.PlayOneShot(dropSound);
    }

    public void PlayVictorySound()
    {
        audioSource.PlayOneShot(victorySound);
    }

    public void PlayThunderSound()
    {
        audioSource.PlayOneShot(thunderSound);
    }

    public void PlayStepSound()
    {
        if (!audioSource.isPlaying) audioSource.PlayOneShot(stepSound);
    }

    public void PlayClimbLadderSound()
    {
        if (!audioSource.isPlaying) audioSource.PlayOneShot(climbLadderSound);
    }


}

