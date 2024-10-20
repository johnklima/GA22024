using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class InteractingObject : MonoBehaviour
{
    public bool interacting = false;
    private CameraProbe cameraProbe;

    // Start is called before the first frame update
    void Start()
    {
        //more efficient to get the component upfront
        cameraProbe = Camera.main.GetComponent<CameraProbe>();

        //could also make it public, and set it manually in the editor. yeah, whatever...
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //meaning if the camera is looking at me
        if(cameraProbe.probeResult == transform)
        {
            Debug.Log("Probing Me " + transform.name);
            if (Input.GetKeyDown(KeyCode.E))
            {                
                interacting = true;

                //do something
                Debug.Log("start interacting");


                //exit now so we have a frame to handle a toggle
                return;

            }

            //if I want continuous press to interact
            if (Input.GetKey(KeyCode.E) && !interacting)
            {
                interacting = true;

                //do something
                Debug.Log("keep interacting");


                //exit now so we have a frame to handle a toggle
                return;
                
            }
        }

        if(interacting)
        {
            //do something
            Debug.Log("I am interacting");

           
            if (Input.GetKey(KeyCode.E))
            {
                //key release
                interacting = false;

                //do something
                Debug.Log("stop interacting");

            }


        }



    }
}
