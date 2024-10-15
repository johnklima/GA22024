using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public float height = 3;
    public float distance = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = target.position - target.forward * distance + target.up * height;  //move camera to player
        transform.LookAt(target);

    }
}
