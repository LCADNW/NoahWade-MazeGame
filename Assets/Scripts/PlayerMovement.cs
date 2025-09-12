using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    float jumpForce = 10;
    
    public float playerSpeed = 5;
    public float sprintSpeed = 2;
    public float playerMaxSpeed = 11;
    public float playerStamina = 200;
    public float playerStaminaDrain = 10;
    Rigidbody rb;


    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bingus");

       rb = GetComponent<Rigidbody>();

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            {
            rb.AddForce(Vector3.forward * playerSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * playerSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * playerSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * playerSpeed, ForceMode.Impulse);
        }
        //whenever Player uses WASD, they move in that direction at PlayerSpeed 5. PlayerSpeed is a public, changeable number.

       
      
       if (Input.GetKeyDown(KeyCode.Space))
        {
          //  transform.transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
            //makes player go UP when pressing Space. As of writing this makes you float into the sky.

            //YouTube Video
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }


        ////Sprint
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    if (playerSpeed <= playerMaxSpeed)
        //    {
        //        playerSpeed *= sprintSpeed;
        //    }
        //}
        //else
        //{
        //    if (playerSpeed >= playerMaxSpeed)
        //    {
        //        Debug.Log("works");
        //        playerSpeed = 5;
        //    }




            //Sprint
            if (Input.GetKey(KeyCode.LeftShift))
        {
            playerStamina = playerStamina - playerStaminaDrain * Time.deltaTime;
 
            if (playerSpeed <= playerMaxSpeed)
            {
                playerSpeed *= sprintSpeed;
            }
        }
             else
        {
            if (playerSpeed >= playerMaxSpeed)
            {
                Debug.Log("works");
                playerSpeed = 5;
            }
            //After Stamina reaches 0, then playerSpeed is permanetly set to 3.
            if (playerStamina <= 0)
            {
                playerSpeed = 3;
                sprintSpeed = 1;
            }
        }
    }
}










