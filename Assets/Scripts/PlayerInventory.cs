using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] inventory;
    public RawImage[] guiSlot;
    
    public int GetFreeSlot()
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
                return i;
        }

        return -1;
    }

    public void Add(int slot, Texture image, Transform obj)
    {
        inventory[slot] = obj;
        guiSlot[slot].texture = image;
        guiSlot[slot].gameObject.SetActive(true);

    }
}
