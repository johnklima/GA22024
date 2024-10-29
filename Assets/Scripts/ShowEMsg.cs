using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowEMsg : MonoBehaviour
{
    public Text Etext;

    private bool killed = false;

    private void Update()
    {
        
    }

    public void ShowE(bool show)
    {
        if(killed == false)
        {
            Etext.gameObject.SetActive(show);
        }
       

    }

    public void KillE()
    {
        killed = true;
        Etext.gameObject.SetActive(false);

    }
}
