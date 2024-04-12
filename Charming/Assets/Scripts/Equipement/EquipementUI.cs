using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipementUI : MonoBehaviour
{
    public Image[] Icon;

    int slotsSize;

    public static EquipementUI instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void updateUI()
    {
        slotsSize = EquipementManager.instance.Equipements.Length;
        for (int i = 0; i < slotsSize; i++)
        {
            // if there is an equipment on this slot
            if (EquipementManager.instance.Equipements[i] != null)
            {
                // then put its respective icon
                Icon[i].sprite = EquipementManager.instance.Equipements[i].Icon;
            }
        }
    }
}
