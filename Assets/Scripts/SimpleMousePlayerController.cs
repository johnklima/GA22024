using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Halvor's & John's controller

public class SimpleMousePlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 10.0f;
    public float GRAVITY = 10.0f;
    public float vSpeed = 0;
    public float jumpSpeed = 8;
        
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // code taken from youtube video from Brackeys  https://www.youtube.com/watch?v=_QajrabyTJc
        // gravity from https://discussions.unity.com/t/gravity-with-character-controller/53805/3

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // this is what allows for the strafing
        //Vector3 xPosition = transform.position + (transform.right * moveSpeed * x * Time.deltaTime);
        //Vector3 zPosition = transform.position + (transform.forward * moveSpeed * z * Time.deltaTime);

        if (controller.isGrounded)
        {
            vSpeed = 0; // grounded character has vSpeed = 0...
            if (Input.GetKeyDown("space"))
            { // unless it jumps:
                vSpeed = jumpSpeed;
            }
        }



        Vector3 move = transform.right * x  + transform.forward * z;

        // apply gravity acceleration to vertical speed:
        vSpeed -= GRAVITY * Time.deltaTime;

        move.y = vSpeed;
        move.x *= moveSpeed;
        move.z *= moveSpeed;

        controller.Move(move * Time.deltaTime);
    }
}
