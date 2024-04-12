using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipmentSerialisation : ItemsSerialisation
{
    public TypeSlots TypeSlot;
    public TypeWeapon TypeWeapon;

    public int DommageModifier;
    public int LifeModifier;
    public int DefenceModifier;
    public int MagicModifier;

    public int Range;

    public int TypeGarment;

    public EquipmentSerialisation(ItemsSerialisation s)
    {
        Name = s.Name;
        Description = s.Description;
        SpriteName = s.SpriteName;

        SellPrice = s.SellPrice;
        BuyPrice = s.BuyPrice;
    }
}
