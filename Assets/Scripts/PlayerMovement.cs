using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;



public class PlayerMovement : MonoBehaviour
{
    public float initialPlayerSpeed = 7f;
    public float currentPlayerSpeed = 7f;
    public float sprintIncrease = 1;
    public float maxSprintSpeed = 12f;
    public float rotSpeed;
   Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currentPlayerSpeed <= maxSprintSpeed)
                currentPlayerSpeed += sprintIncrease;
        }
        else if (currentPlayerSpeed >= initialPlayerSpeed)
            currentPlayerSpeed -= sprintIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W))
        {
            dir = transform.forward;
            rb.AddForce(dir * currentPlayerSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir = -transform.right;
            RotatePlayerInLookDir(dir);
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir = transform.right;
            RotatePlayerInLookDir(dir);
        }

        if (Input.GetKey(KeyCode.S))
        {
            dir = -transform.forward;
            rb.AddForce(dir * currentPlayerSpeed, ForceMode.Impulse);
        }
    }

    void RotatePlayerInLookDir(Vector3 rotDir)
    {
        if (rotDir == Vector3.zero) return;
        Quaternion targetRot = Quaternion.LookRotation(rotDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
    }

}










