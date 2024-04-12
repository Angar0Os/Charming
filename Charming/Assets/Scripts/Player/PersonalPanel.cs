using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalPanel : MonoBehaviour
{
    public Text HpStat;
    public Text AttackStat;
    public Text DefStat;
    public Text MagieStat;
    public Text MouvementStat;
    public Text Point;

    public GameObject PersoPanel;
    public GameObject Inventory;

    public int Constitution = 5;
    public int Attack = 5;
    public int Defence = 5;
    public int Magic = 5;

    public int DefStats;
    public int MagieStats;
    public int HpStats;
    public int AttackStats;
    public int MouvementStats;

    private int dommageArmor;
    private int lifeArmor;
    private int defenceArmor;
    private int magicArmor;

    private int dommageWeapon;
    private int lifeWeapon;
    private int defenceWeapon;
    private int magicWeapon;

    public int Points = 5;

    public static PersonalPanel instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        UpdateStats();
    }

    void Update()
    {
        UpdateStats();
        // if you press i
        if (Time.timeScale == 1f)
        {
            if (Input.GetKeyDown(KeyCode.I) || Input.GetButton("BTB"))
            {
                // open the personal file
                ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.PERSOPANEL);
                PersoPanel.SetActive(true);
            }

            if (Input.GetButtonDown("BTX") && PersoPanel.activeSelf)
            {
                // close your personal file
                ClosePersonalPanel();
            }
        }
    }

    public void IncrementHp(int value)
    {
        // if you want to add skill points
        if (value > 0)
        {
            // if you have skill points
            if (Points > 0)
            {
                // add skill points
                Constitution += value;
                Points--;
            }
        }
        // if you want to withdraw skill points
        else
        {
            // if you have more than five points in this stats
            if (Constitution > 5)
            {
                // suppression of the points of stats
                Constitution += value;
                Points++;
            }
        }
        UpdateUI();
    }
    public void IncrementAttack(int value)
    {
        // if you want to add skill points
        if (value > 0)
        {
            // if you have skill points
            if (Points > 0)
            {
                // add skill points
                Attack += value;
                Points--;
            }
        }
        // if you want to withdraw skill points
        else
        {
            // if you have more than five points in this stats
            if (Attack > 5)
            {
                // suppression of the points of stats
                Attack += value;
                Points++;
            }
        }
        UpdateUI();
    }
    public void IncrementDef(int value)
    {
        // if you want to add skill points
        if (value > 0)
        {
            // if you have skill points
            if (Points > 0)
            {
                // add skill points
                Defence += value;
                Points--;
            }
        }
        // if you want to withdraw skill points
        else
        {
            // if you have more than five points in this stats
            if (Defence > 5)
            {
                // suppression of the points of stats
                Defence += value;
                Points++;
            }
        }
        UpdateUI();
    }
    public void IncrementMagie(int value)
    {
        // if you want to add skill points
        if (value > 0)
        {
            // if you have skill points
            if (Points > 0)
            {
                // add skill points
                Magic += value;
                Points--;
            }
        }
        // if you want to withdraw skill points
        else
        {
            // if you have more than five points in this stats
            if (Magic > 5)
            {
                // suppression of the points of stats
                Magic += value;
                Points++;
            }
        }
        UpdateUI();
    }
    public void IncrementMouvement(int value)
    {
        // if you want to add skill points
        if (value > 0)
        {
            // if you have skill points
            if (Points >= 5)
            {
                // add skill points
                MouvementStats += value;
                Points -= 5;
            }
        }
        // if you want to withdraw skill points
        else
        {
            // if you have more than five points in this stats
            if (MouvementStats > 1)
            {
                // suppression of the points of stats
                MouvementStats += value;
                Points += 5;
            }
        }
        UpdateUI();
    }


    public void GivePoints(int value)
    {
        // add stats points
        Points += value;
        UpdateUI();
    }

    public void OpenInventory()
    {

        // opening of the inventory
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.INVENTORY);
        Inventory.SetActive(true);
    }

    public void ClosePersonalPanel()
    {
        // close the personal page
        InventoryUI.instance.CloseInventoryPanel();
        PersoPanel.SetActive(false);
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.QUEST);
    }

    public void UpdateUI()
    {
        // if there is a chesplat
        if (EquipementManager.instance.Equipements[0] != null)
        {
            // take the chesplat modifier
            dommageArmor = EquipementManager.instance.Equipements[0].DommageModifier;
            lifeArmor = EquipementManager.instance.Equipements[0].LifeModifier;
            defenceArmor = EquipementManager.instance.Equipements[0].DefenceModifier;
            magicArmor = EquipementManager.instance.Equipements[0].MagicModifier;
        }

        // if there is a Weapon
        if (EquipementManager.instance.Equipements[1] != null)
        {
            // take the weapon modifier
            dommageWeapon = EquipementManager.instance.Equipements[1].DommageModifier;
            lifeWeapon = EquipementManager.instance.Equipements[1].LifeModifier;
            defenceWeapon = EquipementManager.instance.Equipements[1].DefenceModifier;
            magicWeapon = EquipementManager.instance.Equipements[1].MagicModifier;
        }
    }
    public void UpdateStats()
    { 
        // adition of all modifiers
        HpStats     = Constitution      + lifeArmor    + lifeWeapon;
        AttackStats = Attack  + dommageArmor + dommageWeapon;
        DefStats    = Defence + defenceArmor + defenceWeapon;
        MagieStats  = Magic   + magicArmor   + magicWeapon;

        // update of all stats
        HpStat.text =        "Points de vie : "       + HpStats.ToString();
        AttackStat.text =    "Points de d'attaque : " + AttackStats.ToString();
        DefStat.text =       "Points de défense : "   + DefStats.ToString();
        MagieStat.text =     "Points de magie : "     + MagieStats.ToString();
        Point.text =         "Points : "              + Points.ToString();
        MouvementStat.text = "Points de mouvement : " + MouvementStats.ToString();
    }
}
