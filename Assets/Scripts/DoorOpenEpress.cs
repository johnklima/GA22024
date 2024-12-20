using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenEpress : MonoBehaviour
{
    public bool isDoorOpen = false;
    public bool isE_pressed = false;

    public Animation doorAnimation;
    public Transform doorGeom;

    private CameraProbe cameraProbe;
    private ShowEMsg eMsg;

    // Start is called before the first frame update
    void Start()
    {
        //just to be sure
        isDoorOpen = false;
        isE_pressed = false;

        cameraProbe = Camera.main.GetComponent<CameraProbe>();
        eMsg = GetComponent<ShowEMsg>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isE_pressed = true;
        }

        if(cameraProbe.probeResult == doorGeom)
        {
            eMsg.ShowE(true);
        }
        else
        {
            eMsg.ShowE(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        isE_pressed = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (isDoorOpen == false && isE_pressed)
            {
                Debug.Log("Player Opens Door E Press");
                doorAnimation.Play();
                isDoorOpen = true;
                eMsg.KillE();
            }
        }
       

    }
    private void OnTriggerExit(Collider other)
    {
        isE_pressed = false;
    }

}
