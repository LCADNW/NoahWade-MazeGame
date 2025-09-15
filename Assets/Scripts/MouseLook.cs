using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float xSens = 1f;
    public float ySens = 1f;

    public Transform orientation;
    public Transform headLoc;

    float yRot, xRot, lookX, lookY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        lookX = Input.GetAxis("Mouse X") * xSens;
        lookY = Input.GetAxis("Mouse Y") * -ySens;

        MouseLooking(lookX, lookY);
    }

    void MouseLooking(float x, float y)
    {
        yRot += y;
        xRot += x;

        yRot = Mathf.Clamp(yRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(0f, xRot, 0f);
        orientation.rotation = Quaternion.Euler(yRot, xRot, 0f);

    }

    private void LateUpdate()
    {
        transform.position = headLoc.transform.position;
    }
}
