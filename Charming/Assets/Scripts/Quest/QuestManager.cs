using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public List<Quest> QuestsInProgress;
    public List<Quest> AllQuest;

    public List<QuestPickUp> PickUpQuest;

    public GameObject QuestPanel;
    public GameObject QuestEndPanel;

    public GameObject QuestInformationPanel;

    public Text NameQuest;
    public Text NameQuestEnd;
    public Text DescriptQuest;

    public Text NameQuestPanel;
    public Text DescriptQuestPanel;
    public Text GoldRewardPanel;
    public Text XpRewardPanel;
    public Text QuestStatus;

    public Quest QuestSelect;

    public static QuestManager instance;
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
        LoadQuest();
    }

    private void Update()
    {
        // verification of all quest status
        for (int i = 0; i < QuestsInProgress.Count; i++)
        {
            // if the quest is in progress
            if (QuestsInProgress[i].StatusQuest == StatusQuest.INPROGRESS)
            {
                QuestsInProgress[i].Evaluate();
            }
            // if the quest is finish
            else if (QuestsInProgress[i].StatusQuest == StatusQuest.FINISH)
            {
                StartCoroutine(DalaiEndQuest(QuestsInProgress[i]));
                RemoveQuest(QuestsInProgress[i]);
            }
        }
    }

    public void StopQuest()
    {
        if (QuestSelect != null)
        {
            // Change of the status of the quest
            QuestSelect.StatusQuest = StatusQuest.FOUND;
            ChangeQuestStatus(QuestSelect);
        }
    }

    public void StartQuest()
    {
        if (QuestSelect != null)
        {
            // Change of the status of the quest
            QuestSelect.StatusQuest = StatusQuest.INPROGRESS;
            ChangeQuestStatus(QuestSelect);
        }
    }

    public void ChangeQuestStatus(Quest quest)
    {
        // Change the status of the quest in the UI
        switch (quest.StatusQuest)
        {
            case StatusQuest.FOUND:      QuestStatus.text = "Trouvé";   break;
            case StatusQuest.INPROGRESS: QuestStatus.text = "En cours"; break;
            default:                                                    break;
        }
    }

    public void SeeQuest(Quest quest)
    {
        // display of the quest
        QuestSelect = quest;
        ChangeQuestStatus(quest);
        QuestInformationPanel.SetActive(true);

        NameQuestPanel.text = quest.Name;
        DescriptQuestPanel.text = quest.Description;

        GoldRewardPanel.text = quest.GoldReward.ToString() + " Gold";
        XpRewardPanel.text = quest.XpReward.ToString() + " Xp";
    }

    public void CloseQuestPanelInformation()
    {
        // close the quest page
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.QUEST);
        QuestInformationPanel.SetActive(false);
    }

    public void NewQuest(Quest quest)
    {
        // added a new quest to the quests
        quest.StatusQuest = StatusQuest.INPROGRESS;

        QuestPanel.SetActive(true);

        NameQuest.text = quest.Name;
        DescriptQuest.text = quest.Description;
        StartCoroutine(Delai(quest));
    }

    public void RemoveQuest(Quest quest)
    {
        // Deletion of a quest in the quests
        QuestsInProgress.Remove(quest);
        QuestUI.instance.UpdateUI();
    }

    public void LoadQuest(List<Quest> quests)
    {
        // load all quest
        QuestsInProgress = quests;
        QuestUI.instance.UpdateUI();
    }

    public void LoadQuest()
    {
        // clear the quets in progress
        QuestsInProgress.Clear();

        // for all the quest available in the game
        for (int i = 0; i < AllQuest.Count; i++)
        {
            // if the quest is in progress or find
            if (AllQuest[i].StatusQuest == StatusQuest.INPROGRESS || AllQuest[i].StatusQuest == StatusQuest.FOUND)
            {
                // add this quest in quest in progress
                QuestsInProgress.Add(AllQuest[i]);
            }
            // for all the triggers available in the game
            for (int l = 0; l < PickUpQuest.Count; l++)
            {
                // if it is in the right place
                if (PickUpQuest[l].transform.tag == AllQuest[i].StartTrigger)
                {
                    // put the quest in this triggers
                    PickUpQuest[l].Quest = AllQuest[i];
                }
            }
        }
        QuestUI.instance.UpdateUI();
    }

    IEnumerator Delai(Quest quest)
    {
        // wait 3 seonds
        yield return new WaitForSeconds(3.5f);
        QuestPanel.SetActive(false);

        LoadQuest();
    }

    IEnumerator DalaiEndQuest(Quest quest)
    {
        QuestEndPanel.SetActive(true);

        NameQuestEnd.text = "La quête " + quest.Name + " est terminé";
        yield return new WaitForSeconds(2.5f);
        QuestEndPanel.SetActive(false);
    }
}