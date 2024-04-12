using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Items", menuName = "Inventory/Ring")]
public class Ring : Items
{
    public override void Use()
    {
        // Launch the item's information page
        InventoryUI.instance.SeeOtherItem(this);
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.INFOOTHERITEM);
    }

    public override string WriteInformation()
    {
        // Display of all the information of the item
        return Description;
    }

    public override ItemsSerialisation CreateSerialisation()
    {
        HealerSerialisation result = new HealerSerialisation(base.CreateSerialisation());

        return result;
    }

    public override void LoadFromSerialisation(ItemsSerialisation s)
    {
        base.LoadFromSerialisation(s);

        HealerSerialisation es = (s as HealerSerialisation);
    }
}
