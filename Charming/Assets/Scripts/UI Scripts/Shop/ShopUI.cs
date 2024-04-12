using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject ParentSlotsBuy;
    public GameObject ParentSlotsSell;

    public Text NameItemBuy;
    public Text NameItemSell;

    public Text PriceBuyItem;
    public Text PriceSellItem;

    public Text StatItemSell;
    public Text StatItemBuy;

    ItemsSlotsInShopBuy[] itemsSlotsInShopsBuy;
    ItemsSlotsInShopSell[] itemsSlotsInShopsSell;

    public static ShopUI instance;
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
        itemsSlotsInShopsBuy = ParentSlotsBuy.GetComponentsInChildren<ItemsSlotsInShopBuy>();
        itemsSlotsInShopsSell = ParentSlotsSell.GetComponentsInChildren<ItemsSlotsInShopSell>();
    }

    public void UpdateItemPanelBuy(Items items)
    {
        // if there are a item in the slots
        if (items != null)
        {
            // put the item information
            Shop.instance.ItemSelectBuy = items;
            NameItemBuy.text = items.Name;

            StatItemBuy.text = items.WriteInformation();
            PriceBuyItem.text = "Prix : " + items.BuyPrice.ToString();
        }
        // if there are not a item in the slots
        else
        {
            // put the item information
            Shop.instance.ItemSelectBuy = null;
            NameItemBuy.text = "Name";

            StatItemBuy.text = "autre information";
            PriceBuyItem.text = "Prix : 0";
        }
    }

    public void UpdateItemPanelSell(Items items)
    {
        // if there are a item in a slot
        if (items != null)
        {
            // put the item information
            Shop.instance.ItemSelectSell = items;
            NameItemSell.text = items.Name;

            StatItemSell.text = items.WriteInformation();
            PriceSellItem.text = "Prix : " + items.SellPrice.ToString();
        }
        // if there are not item in the slot
        else
        {
            // Put the item information
            Shop.instance.ItemSelectBuy = null;
            NameItemSell.text = "Name";

            StatItemSell.text = "autre information";
            PriceSellItem.text = "Prix : 0";
        }
    }

    public void UpdateUI()
    {
        // storage of all items in the shop
        for (int i = 0; i < itemsSlotsInShopsBuy.Length; i++)
        {
            if (i < Shop.instance.Item.Count)
            {
                itemsSlotsInShopsBuy[i].AddItems(Shop.instance.Item[i]);
            }
            else
            {
                itemsSlotsInShopsBuy[i].ClearSlots();
            }
        }

        // storage for all item in the inventory
        for (int i = 0; i < itemsSlotsInShopsSell.Length; i++)
        {
            if (i < Inventory.instance.Items.Count)
            {
                itemsSlotsInShopsSell[i].AddItems(Inventory.instance.Items[i]);
            }
            else
            {
                itemsSlotsInShopsSell[i].ClearSlots();
            }
        }
    }
}
