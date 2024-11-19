using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotator : MonoBehaviour
{

    public Quaternion openRotation;
    public Quaternion closedRotation;
    public bool openIt = false;
    public bool closeIt = false;

    bool isOpen = false;
    bool isClosed = true;

    
    // Start is called before the first frame update
    void Start()
    {
        //just sortof eyeballed the open position
        //turned out to be an accumulation of +30 degrees - accident or math?
        openRotation = transform.rotation;

        transform.Rotate(0, -62, 0);
        closedRotation = transform.rotation;

        isClosed = true;
    }

    // Update is called once per frame
    float t = 0;
    void Update()
    {

       

        if (openIt)
        {
            t += Time.deltaTime;
            if (t >= 1)
            {
                t = 1;
                openIt = false;
            }

           Quaternion rot = Quaternion.Slerp(closedRotation, openRotation, t);

            if (openIt == false)
                t = 0;
            
            transform.rotation = rot;
        }

        if(closeIt)
        {

            t += Time.deltaTime;
            if (t >= 1)
            {
                t = 1;
                closeIt = false;
            }

            Quaternion rot = Quaternion.Slerp(openRotation, closedRotation, t);

            if (closeIt == false)
                t = 0;

            transform.rotation = rot;
        }
    }
}
