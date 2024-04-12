using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchimyUI : MonoBehaviour
{
    public GameObject ParentSlotPotion;
    public GameObject ParentSlotItems;

    public static AlchimyUI instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void UpdateUI()
    {
        // update the potion slots 
        PotionSlots[] slotsAlchimy = ParentSlotPotion.GetComponentsInChildren<PotionSlots>();
        for (int i = 0; i < slotsAlchimy.Length; i++)
        {
            // if i have a item to put 
            if (i < Alchimy.instance.Potions.Count)
            {
                // put this item in inventory slots
                slotsAlchimy[i].AddItems(Alchimy.instance.Potions[i]);
            }
            else
            {
                // clear this inventory slots
                slotsAlchimy[i].ClearSlots();
            }
        }

        // update the inventory slots
        InventorySlotAlchimy[] slotsInventory = ParentSlotItems.GetComponentsInChildren<InventorySlotAlchimy>();
        for (int i = 0; i < slotsInventory.Length; i++)
        {
            // if i have a item to put 
            if (i < Inventory.instance.Items.Count)
            {
                // put this items in inventory slots
                slotsInventory[i].AddItems(Inventory.instance.Items[i]);
            }
            else
            {
                // clear this inventory slots
                slotsInventory[i].ClearSlots();
            }
        }
    }
}
