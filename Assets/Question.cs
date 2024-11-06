using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    public Text questionUI;
    public string textToShow;

    // Start is called before the first frame update
    void Start()
    {
        questionUI.text = textToShow;
    }

}
