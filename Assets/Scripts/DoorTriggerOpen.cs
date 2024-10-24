using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTriggerOpen : MonoBehaviour
{

    public Animation doorAnimation;
    public Transform [] keysNeeded;  //in no order, or require it
    public PlayerInventory keyInventory;


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
        for(int i = 0; i < keyInventory.inventory.Length; i++)
        {
            if (keyInventory.inventory[i] != null)
            {                
                keyCount++;
            }
            
        }
        //test order not just count
        keyCount = 0;

        if ( other.tag == "Player" )
        {
            Debug.Log("player in door trigger");
            if (isDoorOpen == false                              &&
                isE_pressed                                      && 
                ( keyCount == keysNeeded.Length                  ||
                keyInventory.inventory.ToCommaSeparatedString()  == 
                keysNeeded.ToCommaSeparatedString() )             )
            {
                Debug.Log("Player Open Door");
                doorAnimation.Play();
                isDoorOpen = true;
                isE_pressed = false;
            }

        }              
        
    }  

}
