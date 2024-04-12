using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipementManager : MonoBehaviour
{
    public Equipement[] Equipements;

    public static EquipementManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        // found the slots index for this equipement
        int solts = System.Enum.GetNames(typeof(TypeSlots)).Length;
        // equip the equipement in this slot
        Equipements = new Equipement[solts];
    }

    public void LoadEquipement()
    {
        // for all equipement slots
        foreach (var equip in Equipements)
        {
            // if there is a equipement in this slot
            if (equip != null)
            {
                // load the sprite in this slot
                equip.Icon = ManagerIcon.instance.LoadSprite(equip);
            }
        }
        EquipementUI.instance.updateUI();

    }

    public void equip(Equipement newItem)
    {
        int slotsIndex = (int)newItem.TypeSlot;

        Equipement oldItem;

        // if there is already an equipment stored here
        if (Equipements[slotsIndex] != null)
        {
            // add the old items in the inventory 
            oldItem = Equipements[slotsIndex];
            Inventory.instance.Add(oldItem);
        }

        // equip the equipment
        Equipements[slotsIndex] = newItem;
        EquipementUI.instance.updateUI();
        PersonalPanel.instance.UpdateUI();
        PersonalPanel.instance.UpdateStats();
    }
}
