using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    private void OnTriggerEnter(Collider other)
    {
        if ((playerMask.value & (1 << other.gameObject.layer)) == 0) return;
        if (gameObject.GetComponentInParent<Watcher>().alreadyAttacking == false) return;
        other.GetComponent<Jumpscare>().GetJumpscared();

    }
}
