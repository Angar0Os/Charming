using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPickUp : MonoBehaviour
{
    public Quest Quest;

    private void Awake()
    {
        LoadGameManager loadGameManager = GameObject.FindGameObjectWithTag("Launcher").GetComponent<LoadGameManager>();
        if (loadGameManager.TypeLunching == TypeLunching.NEWGAME)
        {
            Quest.StatusQuest = StatusQuest.NONE;
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // if the raycast hits a collision box with this tag
            if (hit.transform.CompareTag(transform.tag))
            {
                if (Quest.StatusQuest == StatusQuest.NONE)
                {
                    // then add this quest
                    QuestManager.instance.NewQuest(Quest);
                }
            }
        }
    }
}
