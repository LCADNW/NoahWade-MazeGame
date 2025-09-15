using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Vector3 lookAtPos;
    private void Update()
    {
        MouseLookRotate();
    }

    void MouseLookRotate()
    {
        Plane grnd = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(grnd.Raycast(ray, out float enter))
        {
            Vector3 hitpoint = ray.GetPoint(enter);
            lookAtPos = hitpoint;
            transform.LookAt(lookAtPos);
        }
    }



}
