using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alchimy : MonoBehaviour
{
    public Text NameItems;
    public Text StatItem;
    public Text PriceItem;
    public Text InfoPotion;

    public List<Healer> Potions;

    public GameObject AlchimyPanel;

    public Items  SellSelected;
    public Healer PotionSelected;

    public Image ImageFirst;
    public Image ImageSeconde;
    public Image ImageCraft;

    public Image BlackFirst;
    public Image BlackSeconde;

    public bool InAlchimy;

    public static Alchimy instance;
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
        if (Input.GetButtonDown("BTX"))
        {
            CloseAlchimy();
        }
    }

    public void OpenAlchimy(List<Healer> potions)
    {
        // put the base value in potion slots and in the sell slots
        SelectPotion(null);
        SelectSell(null);

        // open the alchimie windos
        InAlchimy = true;
        Potions = potions;
        AlchimyUI.instance.UpdateUI();
        // display The alchimy panel
        AlchimyPanel.SetActive(true);
        // change the first button for the input manette
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.ALCHIMY);
        // select the first potion in the alchimist
        SelectPotion(Potions[0]);
    }

    public void CloseAlchimy()
    {
        // close the alchimie windos
        InAlchimy = false;
        // close the alchimy panel
        AlchimyPanel.SetActive(false);
        // change the first select button for the input manette
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.QUEST);
    }

    public void SelectPotion(Healer healer)
    {
        // if there is not potion in this slots
        if (healer == null)
        {
            // set the base value
            PotionSelected = null;
            InfoPotion.text = "Information de la potion";

            ImageFirst.enabled = false;
            ImageSeconde.enabled = false;
            ImageCraft.enabled = false;
            return;
        }
        // set the potion selected
        PotionSelected = healer;
        ImageCraft.sprite = healer.Icon;

        // write a potion information
        InfoPotion.text = healer.WriteInformation();

        // active ths image
        ImageFirst.enabled = false;
        ImageSeconde.enabled = false;
        ImageCraft.enabled = true;

        // if the object have not a first obj for craft
        if (PotionSelected.FirstOBJCraft != null)
        {
            BlackFirst.enabled = false;
            // if i have not a item for craft a potion
            if (!Inventory.instance.HaveItem(PotionSelected.FirstOBJCraft))
            {
                // disable the black panel in first obj
                BlackFirst.enabled = true;
            }
            // display the first potion for craft this item
            ImageFirst.sprite = PotionSelected.FirstOBJCraft.Icon;
            AlchimyUI.instance.UpdateUI();
        }
        ImageFirst.enabled = true;

        // if the obj have not a seconde obj for craft
        if (PotionSelected.SecondeOBJCraft != null)
        {
            BlackSeconde.enabled = false;
            // if i have not a item for craft a potion
            if (!Inventory.instance.HaveItem(PotionSelected.SecondeOBJCraft))
            {
                // disable the black panel in seconde obj
                BlackSeconde.enabled = true;
            }
            // display the second sprite for craft this item
            ImageSeconde.sprite = PotionSelected.SecondeOBJCraft.Icon;
            AlchimyUI.instance.UpdateUI();
        }
        ImageSeconde.enabled = true;
    }

    public void Crafting()
    {
        // if i select a potion
        if (PotionSelected != null)
        {
            // if i have a two obj for craft the obj
            if (Inventory.instance.HaveItem(PotionSelected.FirstOBJCraft) && Inventory.instance.HaveItem(PotionSelected.SecondeOBJCraft))
            {
                // try add the potion in the inventory
                bool isCraft = Inventory.instance.Add(PotionSelected);

                // if is good
                if (isCraft)
                {
                    // remove a two obj for craft the obj
                    PotionSelected.FirstOBJCraft.Remove();
                    PotionSelected.SecondeOBJCraft.Remove();

                    // clear the craft slots
                    ClearCraftSlot();
                }
            }
        }
    }

    public void SelectSell(Items items)
    {
        // if there are a item in this slots
        if (items != null)
        {
            // display the items information
            SellSelected = items;

            StatItem.text = items.WriteInformation();
            NameItems.text = items.Name.ToString();
            PriceItem.text = "Prix : " + items.SellPrice.ToString();
        }
        else
        {
            // display the base information
            StatItem.text = "Information item";
            NameItems.text = "Nom de l'item";
            PriceItem.text = "Prix : 0";
        }
    }

    public void SellItems()
    {
        // if i select a item in the inventory
        if (SellSelected != null)
        {
            // sell this item
            CoinsManager.instance.IncrementCoins(SellSelected.SellPrice);
            SellSelected.Remove();
            SelectSell(null);
        }
    }

    public void ClearCraftSlot()
    {
        // disable all craft image
        ImageFirst.enabled   = false;
        ImageSeconde.enabled = false;
        ImageCraft.enabled   = false;
        AlchimyUI.instance.UpdateUI();
    }
}
