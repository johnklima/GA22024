using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHighlight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.parent.GetComponent<HighlightObject>().Highlight(true, 0.5f);

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
