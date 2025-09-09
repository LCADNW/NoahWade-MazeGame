using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -7);
  

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);


    }
}
