using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Items> Items = new List<Items>();

    public static Inventory instance;

    public int Space = 36;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        LoadItems();
    }

    public bool Add(Items items)
    {
        // if there is not enough space in the inventory
        if (this.Items.Count >= Space)
        {
            return false;
        }

        // add of item in the inventory 
        this.Items.Add(items);

        // update all inventory UI
        InventoryUI.instance.UpdateUI();
        ShopUI.instance.UpdateUI();
        AlchimyUI.instance.UpdateUI();

        return true;
    }

    public bool HaveItem(Items item)
    {
        // for all item in my inventory
        for (int i = 0; i < Items.Count; i++)
        {
            // if this item equal on the item argument
            if (Items[i] == item)
            {
                return true;
            }
        }
        return false;
    }

    public void LoadItems()
    {
        // for all items
        foreach (var item in Items)
        {
            // load the icon items
            item.Icon = ManagerIcon.instance.LoadSprite(item);
        }

        InventoryUI.instance.UpdateUI();
    }

    public void remove(Items items)
    {
        // deletion of the item in the inventory
        this.Items.Remove(items);

        // update all inventory UI
        InventoryUI.instance.UpdateUI();
        ShopUI.instance.UpdateUI();
        AlchimyUI.instance.UpdateUI();
    }
}
