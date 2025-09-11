using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveBounds : MonoBehaviour
{
    public LayerMask enemyMask;

    private void OnTriggerEnter(Collider other)
    {
        if ((enemyMask.value & (1 << other.gameObject.layer)) == 0) return;
        other.GetComponent<Watcher>().isInRangeOfPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if ((enemyMask.value & (1 << other.gameObject.layer)) == 0) return;
        other.GetComponent<Watcher>().isInRangeOfPlayer = false;

    }
}
