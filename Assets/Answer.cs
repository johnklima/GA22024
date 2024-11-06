using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{

    public Text answerUI;
    public string textToShow;

    // Start is called before the first frame update
    void Start()
    {
        answerUI.text = textToShow;
    }

    
}
