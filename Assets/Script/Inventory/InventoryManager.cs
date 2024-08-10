using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated=false;
    private bool delay;
    public Item_Slot[] slot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B) && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        } 
        else if (Input.GetKey(KeyCode.B) && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
    public void AddItem(string itemName, int quanity, Sprite itemSprite, string itemDescription)
    {
        for(int i = 0; i < slot.Length; i++)
        {
            if (slot[i].isFull == false)
            {
                slot[i].additem(itemName, quanity, itemSprite, itemDescription);
                return;
            }
        }        
    }
    public void DeselectAllSlots()
    {
        for(int i = 0; i < slot.Length; i++) {
            slot[i].selectedShader.SetActive(false);
            slot[i].thisitemSelected = false;
        }
    }
}
