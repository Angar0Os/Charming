using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "New Items", menuName = "Inventory/Items")]
 public class Items
    : ScriptableObject
{
    public string Name = "New items";
    public string SpriteName;
    public Sprite Icon = null;

    public string Description;

    public int BuyPrice = 0;
    public int SellPrice = 0;

    public virtual void Use() { }
    public virtual void SecondeUse() { }
    public virtual string WriteInformation() { return Name; }

    public void Remove()
    {
        Inventory.instance.remove(this);
    }

    public virtual ItemsSerialisation CreateSerialisation()
    {
        ItemsSerialisation result = new ItemsSerialisation();

        result.Name = Name;
        result.Description = Description;
        result.SpriteName = Icon.name;

        result.BuyPrice = BuyPrice;
        result.SellPrice = SellPrice;

        return result;
    }

    public virtual void LoadFromSerialisation(ItemsSerialisation s)
    {
        Name = s.Name;
        Description = s.Description;
        SpriteName = s.SpriteName;

        BuyPrice = s.BuyPrice;
        SellPrice = s.SellPrice;
    }
}
