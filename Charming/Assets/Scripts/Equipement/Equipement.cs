using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Items", menuName = "Inventory/Equipement")]
public class Equipement : Items
{
    public TypeSlots TypeSlot;
    public TypeWeapon TypeWeapon;

    public int DommageModifier;
    public int LifeModifier;
    public int DefenceModifier;
    public int MagicModifier;

    public int Range;

    public int TypeGarment;

    public override void Use()
    {
        // Launch the item's information page
        InventoryUI.instance.SeeInfoEquipement(this);
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.INFOEQUIP);
    }

    public override string WriteInformation()
    {
        // Display of all the information of the item
        return "dégâts : " + DommageModifier.ToString() +
            "\nPv : "      + LifeModifier.ToString() +
            "\nDefense : " + DefenceModifier.ToString() +
            "\nMagie : "   + MagicModifier.ToString();
    }
    public override ItemsSerialisation CreateSerialisation()
    {
        EquipmentSerialisation result = new EquipmentSerialisation(base.CreateSerialisation());

        result.TypeSlot = TypeSlot;
        result.TypeWeapon = TypeWeapon;

        result.DommageModifier = DommageModifier;
        result.LifeModifier = LifeModifier;
        result.DefenceModifier = DefenceModifier;
        result.MagicModifier = MagicModifier;

        result.Range = Range;

        result.TypeGarment = TypeGarment;

        return result;
    }

    public override void LoadFromSerialisation(ItemsSerialisation s)
    {
        base.LoadFromSerialisation(s);

        EquipmentSerialisation es = (s as EquipmentSerialisation);
        TypeSlot = es.TypeSlot;
        TypeWeapon = es.TypeWeapon;

        DommageModifier = es.DommageModifier;
        LifeModifier = es.LifeModifier;
        DefenceModifier = es.DefenceModifier;
        MagicModifier = es.MagicModifier;

        Range = es.Range;

        TypeGarment = es.TypeGarment;
    }
}

public enum TypeSlots { Armor, Weapon}
public enum TypeWeapon { DAGUE, HACHE, RAPIERE, BATTON, ARC }
