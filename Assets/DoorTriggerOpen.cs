using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorTriggerOpen : MonoBehaviour
{

    public Animation doorAnimation;
    public Transform keyNeeded;
    public PlayerInventory invCheck;


    private bool isDoorOpen = false;
    private bool isE_pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isE_pressed = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        int keyCount = invCheck.inventory.Length ;

        if ( other.tag == "Player" )
        {
            if (isDoorOpen == false     &&
            isE_pressed && keyCount > 0  )
            {
                Debug.Log("Player Open Door");
                doorAnimation.Play();
                isDoorOpen = true;
                isE_pressed = false;
            }

        } 
                
        
    }
   

}
