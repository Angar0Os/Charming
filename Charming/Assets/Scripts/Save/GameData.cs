using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class GameData
{
    //create values that will be saved in a text file
    public float[] Position;

    public bool Is_Chest_Open;

    public List<ItemsSerialisation> Save_Equipment;
    public List<ItemsSerialisation> Save_Inventory;

    public List<QuestSerialisation> Save_Quest;

    public int Level;
    public int XP;
    public int Hp;
    public int Constitution;
    public int Attack;
    public int Def;
    public int MagicAttack;
    public int DefStat;
    public int MagicStat;
    public int HpStat;
    public int AttackStat;
    public int PmStats;
    public int Points;
    public int Coins;

    public bool IsTavern;
    public bool IsCourt;
    public bool IsGameOver;
    public bool IsForest;
    public bool IsField;
    public bool IsFight;
    public bool IsFinalFight;
    public bool IsEnd;
    public bool IsPrince;



    public GameData(DataManager dataManager)
    {
        // get values into their variables to save them 
        Position = new float[2];
        Position[0] = dataManager.Player.transform.position.x;
        Position[1] = dataManager.Player.transform.position.y;

        //Saving player stats
        Hp = dataManager.Player.GetComponent<HpManager>().currentHp;
        XP = dataManager.Player.GetComponent<XPmanager>().Xp;
        Level = dataManager.Player.GetComponent<XPmanager>().Level;
        
        Constitution = dataManager.Canvas.GetComponent<PersonalPanel>().Constitution;
        Attack = dataManager.Canvas.GetComponent<PersonalPanel>().Attack;
        Def = dataManager.Canvas.GetComponent<PersonalPanel>().Defence;
        MagicAttack = dataManager.Canvas.GetComponent<PersonalPanel>().Magic;
        DefStat = dataManager.Canvas.GetComponent<PersonalPanel>().DefStats;
        MagicStat = dataManager.Canvas.GetComponent<PersonalPanel>().MagieStats;
        HpStat = dataManager.Canvas.GetComponent<PersonalPanel>().HpStats;
        AttackStat = dataManager.Canvas.GetComponent<PersonalPanel>().AttackStats;
        PmStats = dataManager.Canvas.GetComponent<PersonalPanel>().MouvementStats;
        Points = dataManager.Canvas.GetComponent<PersonalPanel>().Points;
        Coins = dataManager.Canvas.GetComponent<CoinsManager>().Coins;

        //Safeguarding the status of the safes
        Is_Chest_Open = dataManager.Chest.GetComponent<ItemsPickUp>().ChestIsOpen;
        Is_Chest_Open = dataManager.Chest2.GetComponent<ItemsPickUp>().ChestIsOpen;

        //Saving music
        IsTavern = dataManager.Tavern.GetComponent<AudioSource>().enabled;
        IsCourt = dataManager.Court.GetComponent<AudioSource>().enabled;
        IsGameOver = dataManager.GameOver.GetComponent<AudioSource>().enabled;
        IsForest = dataManager.Forest.GetComponent<AudioSource>().enabled;
        IsField = dataManager.Field.GetComponent<AudioSource>().enabled;
        IsFight = dataManager.Fight.GetComponent<AudioSource>().enabled;
        IsFinalFight = dataManager.FinalFight.GetComponent<AudioSource>().enabled;
        IsEnd = dataManager.Fin.GetComponent<AudioSource>().enabled;
        IsPrince = dataManager.Prince.GetComponent<AudioSource>().enabled;

       //Saving quest status
        Save_Quest = QuestManager.instance.AllQuest.Select(x => x.CreateSerialisation()).ToList();

        //Saving the equipment
        Save_Equipment = EquipementManager.instance.Equipements.Select(x =>
        {
            if (x != null)
                return x.CreateSerialisation();

            return null;
        }).ToList();

        //Saving the Inventory
        Save_Inventory = Inventory.instance.Items.Select(x =>
        {
            if (x != null)
                return x.CreateSerialisation();

            return null;
        }).ToList();

       
    }
}