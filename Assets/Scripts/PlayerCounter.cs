using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this adds access to the GUI system

public class PlayerCounter : MonoBehaviour
{
    public bool isItTrue = false;
    public int falseUntil = 100;
    public int falseCount = 0;
    public float elapsedTime = 0;
    public int threeSecondCount = 0;

    public string [] timeName;
    
    // Start is called before the first frame update
    void Start()
    {
        //init stuff here
        isItTrue = true;
        elapsedTime = 0;


    }// end of the start scope

    // Update is called once per frame
    void Update()
    {
        
        //do the work of this frame
        if(isItTrue)
        {
            Debug.Log("it's true");
            isItTrue = false ;
        }

        if (!isItTrue)
        {
            Debug.Log("it's false");
            falseCount++;
        }

        if(falseCount > falseUntil)
        {
            isItTrue = true;
            falseCount = 0;
        }

        elapsedTime += Time.deltaTime;

        if(elapsedTime > 3.0f)
        {

            int index = threeSecondCount;

            if (index >= timeName.Length)
                index = timeName.Length - 1;


            Debug.Log("three seconds has elapsed " + timeName[index]);

            elapsedTime = 0.0f;

            threeSecondCount++;

        }

    }//end of update scope

} // end of class  scope
