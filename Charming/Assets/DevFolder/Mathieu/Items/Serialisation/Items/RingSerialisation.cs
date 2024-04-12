using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RingSerialisation : ItemsSerialisation
{
    public RingSerialisation(ItemsSerialisation s)
    {
        Name = s.Name;
        Description = s.Description;
        SpriteName = s.SpriteName;

        SellPrice = s.SellPrice;
        BuyPrice = s.BuyPrice;
    }
}
