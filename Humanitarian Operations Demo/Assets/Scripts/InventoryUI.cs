using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Updates ui everytime a player pickups or drops item from inventory
    void UpdateUI()
    {
        Debug.Log("UPDATING UI");

        for(int i =0; i<slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i].GetComponent<Item>());
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
