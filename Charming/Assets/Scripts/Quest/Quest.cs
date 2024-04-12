using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject
{
    public string Name;
    public string Description;
    public string StartTrigger;

    public int GoldReward;
    public int XpReward;

    public StatusQuest StatusQuest;
    public virtual void Evaluate() { }

    public void Complete()
    {
        if (StatusQuest == StatusQuest.INPROGRESS)
        {
            CoinsManager.instance.IncrementCoins(GoldReward);
            GameObject.FindGameObjectWithTag("Player").GetComponent<XPmanager>().Xp += XpReward;
            StatusQuest = StatusQuest.FINISH;
        }
    }

    public virtual QuestSerialisation CreateSerialisation()
    {
        QuestSerialisation result = new QuestSerialisation();

        result.Name = Name;
        result.Description = Description;
        result.StartTrigger = StartTrigger;

        result.GoldReward = GoldReward;
        result.XpReward = XpReward;

        result.StatusQuest = StatusQuest;

        return result;
    }

    public virtual void LoadFromSerialisation(QuestSerialisation s)
    {
        Name = s.Name;
        Description = s.Description;
        StartTrigger = s.StartTrigger;

        GoldReward = s.GoldReward;
        XpReward = s.XpReward;

        StatusQuest = s.StatusQuest;
    }
}

public enum StatusQuest { NONE, FOUND, INPROGRESS, FINISH }
