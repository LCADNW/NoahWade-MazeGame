using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    float jumpForce = 10;
    public bool movementEnabled = false;
    public float currentSpeed = 4;
    public float initialSpeed = 10f;
    public float sprintSpeedGain = 2f;
    float initialMaxSprintSpeed;
    public float maxSprintSpeed = 30f;
    public float stamina = 200;
    public float staminaDrain = 10;
    Rigidbody rb;


    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bingus");
        initialMaxSprintSpeed = maxSprintSpeed;
       rb = GetComponent<Rigidbody>();

    }

    public void ToggleMovement(bool toggle)
    {
        movementEnabled = toggle;
    }

    private void FixedUpdate()
    {
        if (!movementEnabled) return;
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * currentSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * currentSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * currentSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * currentSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= staminaDrain * Time.deltaTime;

            if (currentSpeed <= maxSprintSpeed)
                currentSpeed += sprintSpeedGain;
            else
                currentSpeed = maxSprintSpeed;

        }
        else
        {
            if (currentSpeed > initialSpeed)
                currentSpeed -= sprintSpeedGain * 2;
            else
                currentSpeed = initialSpeed;

            if (stamina <= 0)
            {
                currentSpeed = initialSpeed * 0.7f;
                maxSprintSpeed = initialMaxSprintSpeed * 0.7f;
            }
        }
    }


}










