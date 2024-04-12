using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HealerSerialisation : ItemsSerialisation
{
    public int HealValue;

    public Items FirstOBJCraft;
    public Items SecondeOBJCraft;

    public HealerSerialisation(ItemsSerialisation s)
    {
        Name = s.Name;
        Description = s.Description;
        SpriteName = s.SpriteName;

        SellPrice = s.SellPrice;
        BuyPrice = s.BuyPrice;
    }
}
