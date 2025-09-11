using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public int currentSection;
    public AudioSource audioSource;

    public int currentIndexOfAmbience;
    public AudioClip[] ambiences;

    private void Start()
    {
        currentSection = 0;
        currentIndexOfAmbience = 0;
        PlayTheCurrent();
        StartCoroutine(CheckSection());
    }

    IEnumerator CheckSection()
    {
        while (true)
        {
            if(currentIndexOfAmbience != currentSection)
            {
                PlayTheCurrent();
                currentIndexOfAmbience = currentSection;
            }
            yield return new WaitForSecondsRealtime(2);
        }
    }

    void PlayTheCurrent()
    {
        audioSource.clip = ambiences[currentSection];
        audioSource.Play();
    }


}
