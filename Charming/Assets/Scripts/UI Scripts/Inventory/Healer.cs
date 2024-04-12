using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Items", menuName = "Inventory/Healer")]
public class Healer : Items
{
    public int HealValue;

    public Items FirstOBJCraft;
    public Items SecondeOBJCraft;

    public override void Use()
    {
        // Launch the item's information page
        InventoryUI.instance.SeeItem(this);
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.INFOITEM);
    }

    public override void SecondeUse()
    {
        InventoryUI.instance.CloseInfoEquip();
        InventoryUI.instance.CloseItem();
        InventoryUI.instance.CloseOtherItem();
        InventoryUI.instance.CloseInventoryPanel();
        Remove();
    }

    public override string WriteInformation()
    {
        // Display of all the information of the item
        return Description;
    }

    public override ItemsSerialisation CreateSerialisation()
    {
        HealerSerialisation result = new HealerSerialisation(base.CreateSerialisation());

        result.HealValue = HealValue;

        result.FirstOBJCraft = FirstOBJCraft;
        result.SecondeOBJCraft = SecondeOBJCraft;

        return result;
    }

    public override void LoadFromSerialisation(ItemsSerialisation s)
    {
        base.LoadFromSerialisation(s);

        HealerSerialisation es = (s as HealerSerialisation);
        HealValue = es.HealValue;

        FirstOBJCraft = es.FirstOBJCraft;
        SecondeOBJCraft = es.SecondeOBJCraft;
    }
}
