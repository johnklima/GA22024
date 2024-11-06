using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Image dialogFrame;
    public Question currentQuestion;
    public NPCmovement npcMove;
    public bool isComplete = false;
    
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
        if (isComplete)
            return;


        dialogFrame.gameObject.SetActive(show);
    }

    public void AnswerSelected(int which)
    {
        Transform answer = currentQuestion.transform.GetChild(which);
        
        //are we at the end of the dialog chain?
        bool endDialog = answer.GetComponent<Answer>().AnswerResponseDone();
        
        if(endDialog)
        {
            EndDialog();
        }
    }
    public void EndDialog()
    {
        //pass it up the chain
        npcMove.EndDialog();

        //hide dialog UI
        dialogFrame.gameObject.SetActive(false);

        //reset dialog or just disable it?
        isComplete = true;
    }
}
