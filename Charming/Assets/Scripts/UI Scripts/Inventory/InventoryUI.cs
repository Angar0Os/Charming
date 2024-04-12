using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject InventoryPanel;
    public Transform InventorySlotsParent;

    public Text DiffHP;
    public Text DiffAttack;
    public Text DiffDef;
    public Text DiffMagic;

    public Text ItemDescription;
    public Text OtherItemDescription;

    public GameObject InfoEquipPanel;
    public GameObject InfoItem;
    public GameObject InfoOtherItem;

    public Image NewItem;
    public Image Items;

    public Image ItemPicture;
    public Image OtherItemPicture;

    private Equipement equipementSelecte;
    private Items itemSelect;

    ItemsSlots[] slots;

    public static InventoryUI instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void CloseInventoryPanel()
    {
        // close the inventory page and all info item panel
        InventoryPanel.SetActive(false);
        CloseOtherItem();
        CloseItem();
        CloseInfoEquip();

        // change the first selected
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.PERSOPANEL);
    }

    public void SeeInfoEquipement(Equipement equipement)
    {
        // Display of the equipment page
        equipementSelecte = equipement;
        InfoEquipPanel.SetActive(true);

        // Displaying the images of the equipment page
        NewItem.sprite = equipement.Icon;
        Items.sprite   = EquipementUI.instance.Icon[(int)equipement.TypeSlot].sprite;

        // calculation of the difference in statistics
        int DifferenceAttack  = (equipement.DommageModifier - (EquipementManager.instance.Equipements[(int)equipement.TypeSlot] != null ? EquipementManager.instance.Equipements[(int)equipement.TypeSlot].DommageModifier : 0));
        int DifferenceVie     = (equipement.LifeModifier    - (EquipementManager.instance.Equipements[(int)equipement.TypeSlot] != null ? EquipementManager.instance.Equipements[(int)equipement.TypeSlot].LifeModifier    : 0));
        int DifferenceDefense = (equipement.DefenceModifier - (EquipementManager.instance.Equipements[(int)equipement.TypeSlot] != null ? EquipementManager.instance.Equipements[(int)equipement.TypeSlot].DefenceModifier : 0));
        int DifferenceMagie   = (equipement.MagicModifier   - (EquipementManager.instance.Equipements[(int)equipement.TypeSlot] != null ? EquipementManager.instance.Equipements[(int)equipement.TypeSlot].MagicModifier   : 0));

        // Display of the difference
        DiffHP.text     = "vie : "     + DifferenceVie.ToString();
        DiffAttack.text = "Attaque : " + DifferenceAttack.ToString();
        DiffDef.text    = "Défense : " + DifferenceDefense.ToString();
        DiffMagic.text  = "Magie : "   + DifferenceMagie.ToString();

        // change the color of the text depending on whether the number is positive or negative
        DiffHP.color     = (DifferenceVie     > 0 ? Color.green : DifferenceVie     < 0 ? Color.red : Color.black);
        DiffAttack.color = (DifferenceAttack  > 0 ? Color.green : DifferenceAttack  < 0 ? Color.red : Color.black);
        DiffDef.color    = (DifferenceDefense > 0 ? Color.green : DifferenceDefense < 0 ? Color.red : Color.black);
        DiffMagic.color  = (DifferenceMagie   > 0 ? Color.green : DifferenceMagie   < 0 ? Color.red : Color.black);
    }

    public void SeeItem(Items items)
    {
        // Display of the Item page
        InfoItem.SetActive(true);
        itemSelect = items;

        // display of item information
        ItemDescription.text = items.Description;
        ItemPicture.sprite = items.Icon;
    }

    public void SeeOtherItem(Items items)
    {
        // Display of the Item page
        InfoOtherItem.SetActive(true);
        itemSelect = items;

        // display of item information
        OtherItemDescription.text = items.Description;
        OtherItemPicture.sprite = items.Icon;
    }

    public void CloseItem()
    {
        // close the item page
        InfoItem.SetActive(false);
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.INVENTORY);
    }

    public void CloseOtherItem()
    {
        // close the item page
        InfoOtherItem.SetActive(false);
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.INVENTORY);
    }

    public void CloseInfoEquip()
    {
        // close the item page
        InfoEquipPanel.SetActive(false);
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.INVENTORY);
    }

    public void UseItem()
    {
        // Use of the object
        itemSelect.SecondeUse();
    }

    public void Equip()
    {
        // Use of the object
        EquipementManager.instance.equip(equipementSelecte);
        equipementSelecte.Remove();
        CloseInfoEquip();
    }

    public void UpdateUI()
    {
        // recovery of all slots in the inventory
        slots = InventorySlotsParent.GetComponentsInChildren<ItemsSlots>();

        // storage of all items in the inventory
        for (int i = 0; i < slots.Length; i++)
        {
            // if i have ever a item here
            if (i < Inventory.instance.Items.Count)
            {
                // add a item in this slot
                slots[i].AddItems(Inventory.instance.Items[i]);
            }
            else
            {
                // clear this slots
                slots[i].ClearSlots();
            }
        }
    }
}
