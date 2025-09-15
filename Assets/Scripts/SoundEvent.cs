using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    AudioSource aSource;
    public AudioClip clip;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void PlaySoundEvent()
    {
        if (aSource == null || clip == null) return;
        
        aSource.PlayOneShot(clip);
    }
}
