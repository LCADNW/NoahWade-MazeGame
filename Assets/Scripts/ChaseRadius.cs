using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseRadius : MonoBehaviour
{
    public LayerMask watchers;
    private void OnTriggerStay(Collider other)
    {
        if ((watchers.value & (1 << other.gameObject.layer)) == 0) return;
        print("Watcher in range");

        if (other.gameObject.GetComponent<Watcher>().alreadyAttacking == false) return;

        print("Watcher attacking");

        if (PlayerSingleton.Instance.GetComponent<MusicPlayer>().inChase) return;

        print("player not already in chase");

        PlayerSingleton.Instance.GetComponent<MusicPlayer>().PlayChase();
    }
}
