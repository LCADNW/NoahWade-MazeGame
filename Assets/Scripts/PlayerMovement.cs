using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    float jumpForce = 10;
    
    public float playerSpeed = 5;
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
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        }
        //whenever Player uses WASD, they move in that direction at PlayerSpeed 5. PlayerSpeed is a public, changeable number.

       
      
       if (Input.GetKeyDown(KeyCode.Space))
        {
          //  transform.transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
            //makes player go UP when pressing Space. As of writing this makes you float into the sky.

            //YouTube Video
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

        //Attempting Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
           
            {
                    playerSpeed = 15;
                }
            
        }
        else
        {

            playerSpeed = 5;


        }



    }


}










