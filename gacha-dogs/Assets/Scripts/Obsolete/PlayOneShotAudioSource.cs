using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayOneShotAudioSource : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (sound != null)
            _audio.PlayOneShot(sound);
    }
}
