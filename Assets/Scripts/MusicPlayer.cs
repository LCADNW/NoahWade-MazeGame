using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class MusicPlayer : MonoBehaviour
{
    public int currentSection;
    public AudioSource audioSource;

    public int currentIndexOfAmbience;
    public AudioClip[] ambiences;
    public AudioClip chaseMusic;
    int directPlayPreviousSection = 0;
    public bool inChase = false;

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
            if (!inChase)
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

    public void AdvanceToSection(int section)
    {
        if (section <= currentSection) return;
        currentSection = section;
        currentIndexOfAmbience = currentSection;
        PlayTheCurrent();
    }

    public void PlayChase()
    {
        inChase = true;
        audioSource.clip = chaseMusic;
        audioSource.Play();
    }


}
