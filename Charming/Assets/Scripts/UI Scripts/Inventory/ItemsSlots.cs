using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsSlots : MonoBehaviour
{
    Items item;

    public Image Icon;

    public void AddItems(Items newItem)
    {
        // put the item in the slot
        item = newItem;

        // put the icon of the item in the slot
        Icon.sprite = item.Icon;
        Icon.enabled = true;
    }

    public void ClearSlots()
    {
        // remove the item from the slot
        item = null;
        // remove the icon from the item
        Icon.sprite = null;
        Icon.enabled = false;
    }

    public void UseItem()
    {
        // if there is a item
        if (item != null)
        {
            // launch this use function
            item.Use();
        }
    }
}
