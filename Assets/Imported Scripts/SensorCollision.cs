using UnityEngine;
using System;

public class SensorCollision : MonoBehaviour
{
    public bool inRange;
    public Transform lastSeenLoc;
    Collider collider;
    public int canTriggerWithLayer;

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
