using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{

    public PlayerInventory toAdd;
    public Texture InvImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player" )
        {
            int index = toAdd.GetFreeSlot();

            if(index < 0)
            {
                Debug.Log("Out of slots");
                return;
            }


            toAdd.Add(index, InvImage, transform);

            transform.gameObject.SetActive(false);
           
            
        }
    }
}
