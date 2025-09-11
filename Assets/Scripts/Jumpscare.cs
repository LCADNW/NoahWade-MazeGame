using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpscareSound;
    public GameObject[] jumpsacreImages;
    public void GetJumpscared()
    {
        print("Getting Jumpscared");
        int randomImage = Random.Range(0, jumpsacreImages.Length);

        jumpsacreImages[randomImage].SetActive(true);
        audioSource.clip = jumpscareSound;
        audioSource.Play();
    }
}
