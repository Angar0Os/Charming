using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    
    //declare GameObjects and values
    public GameObject Player;
    public GameObject Canvas;
    public GameObject Chest;
    public GameObject Chest2;
    public GameObject Tavern;
    public GameObject Court;
    public GameObject GameOver;
    public GameObject Forest;
    public GameObject Field;
    public GameObject Fight;
    public GameObject FinalFight;
    public GameObject Fin;
    public GameObject Prince;

    public static DataManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void SaveData()
    {
        //Save all datas that are in this file
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        //use loadData
        GameData data = SaveSystem.LoadData();
                
        //set to player his position that was saved
        Vector2 position;
        position.x = data.Position[0];
        position.y = data.Position[1];

        if(Player == null)
        {
            return;
        }
        else
        {
            Player.transform.position = position;
        }

        //  set to chest his boolean value that was saved
        Chest.GetComponent<ItemsPickUp>().ChestIsOpen = data.Is_Chest_Open;
        Chest2.GetComponent<ItemsPickUp>().ChestIsOpen = data.Is_Chest_Open;

        //Loading of the inventory
        Inventory.instance.Items = data.Save_Inventory.Select(x =>
        {
            Items newItem = null;

            if (x is EquipmentSerialisation)
                newItem = ScriptableObject.CreateInstance<Equipement>();
            else if (x is HealerSerialisation)
                newItem = ScriptableObject.CreateInstance<Healer>();
            else if (x is RingSerialisation)
                newItem = ScriptableObject.CreateInstance<Ring>();


            if (newItem != null)
                    newItem.LoadFromSerialisation(x);

            return newItem;
        }).ToList();
        Inventory.instance.LoadItems();

        //Loading player stats
        Player.GetComponent<HpManager>().currentHp = data.Hp;
        Player.GetComponent<XPmanager>().Level = data.Level;
        Player.GetComponent<XPmanager>().Xp = data.XP;

        Canvas.GetComponent<PersonalPanel>().Constitution = data.Constitution;
        Canvas.GetComponent<PersonalPanel>().Attack = data.Attack;
        Canvas.GetComponent<PersonalPanel>().Defence = data.Def;
        Canvas.GetComponent<PersonalPanel>().Magic = data.MagicAttack;
        Canvas.GetComponent<PersonalPanel>().DefStats = data.DefStat;
        Canvas.GetComponent<PersonalPanel>().MagieStats = data.MagicStat;
        Canvas.GetComponent<PersonalPanel>().HpStats = data.HpStat;
        Canvas.GetComponent<PersonalPanel>().AttackStats = data.AttackStat;
        Canvas.GetComponent<PersonalPanel>().MouvementStats = data.PmStats;
        Canvas.GetComponent<PersonalPanel>().Points = data.Points;
        Canvas.GetComponent<CoinsManager>().Coins = data.Coins;

        //Loading of the equipement
        Canvas.GetComponent<EquipementManager>().Equipements = data.Save_Equipment.Select(x =>
        {
            if (x != null)
            {
                Equipement e = ScriptableObject.CreateInstance<Equipement>();
                e.LoadFromSerialisation(x);
                return e;
            }
            return null;
        }).ToArray();
        Canvas.GetComponent<EquipementManager>().LoadEquipement();

        //Loading of the quest status
        Canvas.GetComponent<QuestManager>().AllQuest = data.Save_Quest.Select(x =>
        {
            Quest e = null;
            
            if (x is QuestGoalTriggerSerialisation)
                e = ScriptableObject.CreateInstance<QuestGoalTrigger>();
            // else if (x is ...)
                // e = ScriptableObject.CreateInstance<...>();
            else
                e = ScriptableObject.CreateInstance<Quest>();

            e.LoadFromSerialisation(x);
            return e;
        }).ToList();

        //Loading of the audio source
        Tavern.GetComponent<AudioSource>().enabled = data.IsTavern;
        Court.GetComponent<AudioSource>().enabled = data.IsCourt;
        GameOver.GetComponent<AudioSource>().enabled = data.IsGameOver;
        Forest.GetComponent<AudioSource>().enabled = data.IsForest;
        Field.GetComponent<AudioSource>().enabled = data.IsField;
        Fight.GetComponent<AudioSource>().enabled = data.IsFight;
        FinalFight.GetComponent<AudioSource>().enabled = data.IsFinalFight;
        Fin.GetComponent<AudioSource>().enabled = data.IsEnd;
        Prince.GetComponent<AudioSource>().enabled= data.IsPrince;


        Canvas.GetComponent<QuestManager>().LoadQuest();

        Canvas.GetComponent<PersonalPanel>().UpdateUI();
        Canvas.GetComponent<PersonalPanel>().UpdateStats();

    }

    public void ResetPlayerData()
    {
        SaveSystem.ResetData();
    }

    public bool HaveSave()
    {
        return SaveSystem.HaveSave();
    }

}


