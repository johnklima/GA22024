using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHighlight : MonoBehaviour
{
    public float intensity = 0.65f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.parent.GetComponent<HighlightObject>().Highlight(true, intensity);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            transform.parent.GetComponent<HighlightObject>().Highlight(false, 0);

        }

    }
}
