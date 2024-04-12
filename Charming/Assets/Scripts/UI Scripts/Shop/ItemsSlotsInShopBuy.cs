using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsSlotsInShopBuy : MonoBehaviour
{
    private Items item;

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
        // if there is a item in this slot
        if (item != null)
        {
            // display the item information
            ShopUI.instance.UpdateItemPanelBuy(item);
        }
        // if there is not a item in this slot
        else
        {
            // display the null information
            ShopUI.instance.UpdateItemPanelBuy(null);
        }
    }
}
