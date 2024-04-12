using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSlots : MonoBehaviour
{
    public Text NameQuest;
    public RawImage Slot;

    private Quest quest;

    public void AddQuest(Quest quest)
    {
        // add quest in UI
        this.quest = quest;

        Slot.enabled = true;

        NameQuest.enabled = true;
        NameQuest.text = quest.Name;
    }

    public void Clear()
    {
        // remove Quest on UI
        this.quest = null;

        NameQuest.enabled = false;
        Slot.enabled = false;
    }

    public void OnClick()
    {
        // display quest on UI
        QuestManager.instance.SeeQuest(quest);
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.CLOSEQUEST);
    }
}
