using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Image dialogFrame;
    public Question currentQuestion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialog(bool show)
    {
        dialogFrame.gameObject.SetActive(show);
    }

    public void AnswerSelected(int which)
    {
        Transform answer = currentQuestion.transform.GetChild(which);
        answer.GetComponent<Answer>().AnswerResponse();

    }
}
