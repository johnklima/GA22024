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
    void Update()
    {
        if(openIt)
        {
            transform.rotation = openRotation;
        }
        if(closeIt)
        {
            transform.rotation = closedRotation;
        }
    }
}
