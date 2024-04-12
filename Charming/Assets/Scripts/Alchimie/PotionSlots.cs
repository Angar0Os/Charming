using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionSlots : MonoBehaviour
{
    Healer item;

    public Image Icon;

    public void AddItems(Healer newItem)
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
            Alchimy.instance.SelectPotion(item);
        }
        // if there is not item in this slot
        else
        {
            Alchimy.instance.SelectPotion(null);
        }
    }
}
