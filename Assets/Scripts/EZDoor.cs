using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZDoor : MonoBehaviour
{

    public bool isDoorOpen = false;
    public Animation doorAnimation;

    // Start is called before the first frame update
    void Start()
    {
        isDoorOpen = false;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(isDoorOpen == false)
        {
            Debug.Log("Player Opens EZDoor");
            doorAnimation.Play();
            isDoorOpen = true;
        }

    }
}
