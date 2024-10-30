using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] inventory;
    public RawImage[] guiSlot;
    public RawImage selected;

    public Transform activeItem;
    public int activeItemIndex = -1;
    
    public int GetFreeSlot()
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
                return i;
        }

        return -1;
    }

    public void Add(Texture image, Transform obj)
    {
        int slot = GetFreeSlot();

        if(slot < 0)
        {
            Debug.Log("No slots in inventory");
            return;

        }

        inventory[slot] = obj;
        guiSlot[slot].texture = image;
        guiSlot[slot].gameObject.SetActive(true);
        selected.rectTransform.position = guiSlot[slot].rectTransform.position;
        selected.gameObject.SetActive(true);
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1) && guiSlot[0].isActiveAndEnabled)
        {
            selected.rectTransform.position = guiSlot[0].rectTransform.position;
            activeItemIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && guiSlot[1].isActiveAndEnabled )
        {
            selected.rectTransform.position = guiSlot[1].rectTransform.position;
            activeItemIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && guiSlot[2].isActiveAndEnabled )
        {
            selected.rectTransform.position = guiSlot[2].rectTransform.position;
            activeItemIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && guiSlot[3].isActiveAndEnabled )
        {
            selected.rectTransform.position = guiSlot[3].rectTransform.position;
            activeItemIndex = 3;
        }

        //nothing selected yet?
        if(activeItemIndex < 0)
        {
            return;
        }

        //make sure I have one before I hide it
        if (activeItem)
        {
            activeItem.gameObject.SetActive(false);
        }
       
        //try to activate (slot might be null)     
        activeItem = inventory[activeItemIndex];
        if(activeItem)
        {
            activeItem.parent = Camera.main.transform;
            activeItem.transform.localPosition = Vector3.zero
                                               + Vector3.forward * 3;

            activeItem.gameObject.SetActive(true);

        }
       
    }
}
