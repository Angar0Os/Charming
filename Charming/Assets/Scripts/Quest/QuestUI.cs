using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    QuestSlots[] currentQuest;

    public GameObject ParentQuestSlot;

    public static QuestUI instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void UpdateUI()
    {
        // storage of all items in the Quest
        currentQuest = ParentQuestSlot.GetComponentsInChildren<QuestSlots>();

        // for all quest slots
        for (int i = 0; i < currentQuest.Length; i++)
        {
            // if i can put the quest in this slot
            if (i < QuestManager.instance.QuestsInProgress.Count)
            {
                // put this quest in one slot
                currentQuest[i].AddQuest(QuestManager.instance.QuestsInProgress[i]);
            }
            else
            {
                // clear this slot
                currentQuest[i].Clear();
            }
        }
    }

    public void OpenWindosQuest()
    {
        if (!Dialogue.instance.EndDialogue)
        {
            // if we are in dialogue then close the quest windos
            CloseWindos();
        }
        else
        {
            if (!ParentQuestSlot.activeSelf)
            {
                // open the windos all quest 
                OpenWindos();
                return;
            }
            else
            {
                // close the all quest
                CloseWindos();
            }
        }
    }

    public void OpenWindos()
    {
        // open quest Windos
        ParentQuestSlot.SetActive(true);
    }

    public void CloseWindos()
    {
        // close quest Windos
        ParentQuestSlot.SetActive(false);
    }
}
