using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorTriggerOpen : MonoBehaviour
{

    public Animation doorAnimation;
    public Transform [] keysNeeded;  //in no order, but a prob to require it
    public PlayerInventory invCheck;


    public bool isDoorOpen = false;
    public bool isE_pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        //just to be sure
        isDoorOpen = false;
        isE_pressed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isE_pressed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //just to be sure
        isE_pressed = false;
    }

    private void OnTriggerStay(Collider other)
    {
        int keyCount = 0;
        
        //iterate the player's key inventory
        for(int i = 0; i < invCheck.inventory.Length; i++)
        {
            if (invCheck.inventory[i] != null)
            {
                //we could add order of collection here, which defatco means  the "correct" keys

                keyCount++;
            }
            
        }

        //does this also work?
        if (invCheck.inventory.ToString() == keysNeeded.ToString())
            Debug.Log("yup that works both count and sequence");


        if ( other.tag == "Player" )
        {
            Debug.Log("player in door trigger");
            if (isDoorOpen == false     &&
            isE_pressed && keyCount == keysNeeded.Length)
            {
                Debug.Log("Player Open Door");
                doorAnimation.Play();
                isDoorOpen = true;
                isE_pressed = false;
            }

        }              
        
    }  

}
