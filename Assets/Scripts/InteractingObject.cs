using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingObject : MonoBehaviour
{

    private CameraProbe cameraProbe;
    private HighlightObject highlight;
    private bool wasHighlighting = false;

    public float intensity = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        //more efficient to get the component upfront
        //could also make it public, and set it manually in the editor. yeah, whatever...
        cameraProbe = Camera.main.GetComponent<CameraProbe>();
        highlight = transform.GetComponent<HighlightObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraProbe.probeResult == transform)
        {
            Debug.Log("Probing Me " + transform.name);

            if(highlight )
            {
                highlight.Highlight(true, intensity);
                wasHighlighting = true;
            }
                

        }
        else 
        {
            if (highlight && wasHighlighting)
            {
                highlight.Highlight(false, 0);

            }
                

        }

    }
}
