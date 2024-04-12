using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Items> Item;

    public Items ItemSelectSell;
    public Items ItemSelectBuy;

    public GameObject ShopLabel;

    public bool InShop;

    public delegate void OnItemsChangeInShop();
    public OnItemsChangeInShop ItemsChangeInShop;

    public static Shop instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (Input.GetButton("BTX") && ShopLabel.activeSelf)
        {
            CloseShop();
        }
    }

    public void CloseShop()
    {
        // clsoe a Shop windos
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.QUEST);
        InShop = false;
        ShopLabel.SetActive(false);
    }

    public void BuyItem()
    {
        // if there are a item select for buy
        if (ItemSelectBuy != null)
        {
            // if i have a coins
            if (ItemSelectBuy.BuyPrice <= CoinsManager.instance.Coins)
            {
                if (CoinsManager.instance.Coins > 0)
                {
                    // try to add this item in inventory
                    bool isBuy = Inventory.instance.Add(ItemSelectBuy);

                    // if is good
                    if (isBuy)
                    {
                        // Withdrawn a money 
                        CoinsManager.instance.IncrementCoins(-ItemSelectBuy.BuyPrice);
                        ShopUI.instance.UpdateItemPanelBuy(null);
                    }
                }
            }
        }
    }

    public void SellItem()
    {
        // there are a item select for sell
        if (ItemSelectSell != null)
        {
            // if we have thus item in inventory
            if (Inventory.instance.HaveItem(ItemSelectSell))
            {
                // sell item
                Inventory.instance.remove(ItemSelectSell);
                CoinsManager.instance.IncrementCoins(ItemSelectSell.SellPrice);
                ShopUI.instance.UpdateItemPanelSell(null);
            }
        }
    }

    public void NewShop(List<Items> _items)
    {
        // display the windos Shop
        InShop = true;
        ShopLabel.SetActive(true);

        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.SHOP);

        Item = _items;
        ShopUI.instance.UpdateUI();
    }
}
