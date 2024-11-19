using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentSystem : MonoBehaviour
{
    public bool openIt;
    public bool closeIt;
    // Update is called once per frame
    void Update()
    {
        
        if(openIt && !closeIt)
        { 
            foreach(Transform child in transform)
            {

                BladeRotator br = child.GetChild(0).GetComponent<BladeRotator>();
                if(br)
                {
                    br.openIt = true;

                }
            }

            openIt = false;
        }

        if (closeIt && !openIt)
        {
            foreach (Transform child in transform)
            {

                BladeRotator br = child.GetChild(0).GetComponent<BladeRotator>();
                if (br)
                {
                    br.closeIt = true;
                }
            }

            closeIt = false;
        }


    }
}
