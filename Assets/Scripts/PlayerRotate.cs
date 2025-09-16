using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Vector3 lookAtPos;
    public LayerMask floor;
    private void Update()
    {
        MouseLookRotate();
    }

    void MouseLookRotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 500f, floor))
        {
            Vector3 pos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            lookAtPos = pos;
            Quaternion targetRot = Quaternion.LookRotation(pos - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 10f);
        }
    }



}
