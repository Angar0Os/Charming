using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestGoalTriggerSerialisation : QuestSerialisation
{
    public string TriggerTag;

    public QuestGoalTriggerSerialisation(QuestSerialisation s)
    {
        Name = s.Name;
        Description = s.Description;

        GoldReward = s.GoldReward;
        XpReward = s.XpReward;

        StatusQuest = s.StatusQuest;
    }
}
