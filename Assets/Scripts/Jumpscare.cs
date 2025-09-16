using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpscareSound;
    public GameObject[] jumpsacreImages;
    public UnityEvent OnJumpscared;
    public void GetJumpscared()
    {
        if (!enabled) return;
        print("Getting Jumpscared");
        int randomImage = Random.Range(0, jumpsacreImages.Length);

        jumpsacreImages[randomImage].SetActive(true);
        audioSource.clip = jumpscareSound;
        audioSource.Play();
        OnJumpscared?.Invoke();
        enabled = false;
    }

   
}
