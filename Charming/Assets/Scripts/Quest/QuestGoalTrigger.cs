using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Items", menuName = "Quest/TriggerQuest")]
public class QuestGoalTrigger : Quest
{
    public string TriggerTag;

    public override void Evaluate()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // if the quest is in progress
            if (StatusQuest == StatusQuest.INPROGRESS)
            {
                // if the raycast tuch the collider box with this tag
                if (hit.transform.CompareTag(TriggerTag))
                {
                    Complete();
                }
            }
        }
    }

    public override QuestSerialisation CreateSerialisation()
    {
        QuestGoalTriggerSerialisation result = new QuestGoalTriggerSerialisation(base.CreateSerialisation());

        result.TriggerTag = TriggerTag;

        return result;
    }

    public override void LoadFromSerialisation(QuestSerialisation s)
    {
        base.LoadFromSerialisation(s);

        QuestGoalTriggerSerialisation es = (s as QuestGoalTriggerSerialisation);

        TriggerTag = es.TriggerTag;
    }
}
