using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    public Text questionUI;

    //make a nice big box in editor
    [TextArea(10, 10)] public string textToShow;

    // Start is called before the first frame update
    void Start()
    {
        questionUI.text = textToShow;
    }

}
