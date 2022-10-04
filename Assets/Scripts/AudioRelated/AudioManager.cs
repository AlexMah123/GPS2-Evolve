using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
//HYZ
//Not for BGM
public class AudioManager : MonoBehaviour
{

    [SerializeField]AudioSource audioSource
    {
        get { return GetComponent<AudioSource>(); } 
    }
    [SerializeField] private AudioClip[] clips;

    public void PlaySound(string clipName)
    {
        AudioClip ac = Array.Find(clips, AudioClip => AudioClip.name == clipName);
        audioSource.PlayOneShot(ac);
    }
}
