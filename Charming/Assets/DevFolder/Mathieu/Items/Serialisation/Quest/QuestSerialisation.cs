using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestSerialisation
{
    public string Name;
    public string Description;
    public string StartTrigger;

    public int GoldReward;
    public int XpReward;

    public StatusQuest StatusQuest;
}
