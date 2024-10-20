using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMousePlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // code taken from youtube video from Brackeys  https://www.youtube.com/watch?v=_QajrabyTJc


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // this is what allows for the strafing
        Vector3 xPosition = transform.position + (transform.right * moveSpeed * x * Time.deltaTime);
        Vector3 zPosition = transform.position + (transform.forward * moveSpeed * z * Time.deltaTime);


        Vector3 move = transform.right * x  + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
