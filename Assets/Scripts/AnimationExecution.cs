using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExecution : MonoBehaviour
{
    public Animator animator;

    public void Play(string clip)
    {
        print($"Playing animation {clip}");
        animator.CrossFade(clip, 02f);
    }
}
