using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{

    public Text answerUI;
    
    //make a nice big box in editor
    [TextArea(10, 10)] public string textToShow;

    // Start is called before the first frame update
    void Start()
    {
        answerUI.text = textToShow;
    }

    public void AnswerResponse()
    {
        if(transform.childCount > 0)
        {

            transform.GetChild(0).gameObject.SetActive(true);
        }

    }

}
