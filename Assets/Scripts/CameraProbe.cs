using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProbe : MonoBehaviour
{
    public float probeDepth = 100;
    public Transform probeResult;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //probe on anything start a bit in front of the camera
        if (Physics.Raycast(transform.position + transform.forward, transform.forward, out RaycastHit hitInfo, probeDepth) )
        {
            Debug.Log("Camera probing " + hitInfo.collider.name);
            probeResult = hitInfo.collider.transform;

           
        }
        else if(probeResult) 
        {
            probeResult = null;
        }

    }
}
