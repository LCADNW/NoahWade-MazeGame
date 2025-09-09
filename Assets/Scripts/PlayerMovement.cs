using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5;
   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bingus");












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

       
        //Attempting Jump
    //   if (Input.GetKey(KeyCode.Space))
        {
     //       transform.transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
            //makes player go UP when pressing Space. As of writing this makes you float into the sky.
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










