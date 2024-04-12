using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TypeFirstBT
{
    PERSOPANEL,
    INVENTORY,
    SHOP,
    QUEST,
    CLOSEQUEST,
    PAUSE,
    INFOEQUIP,
    INFOITEM,
    INFOOTHERITEM,
    ALCHIMY
}

public class ForInputManette : MonoBehaviour
{
    public EventSystem EventSystem;

    public static ForInputManette instance;

    public GameObject PeroPanelBT;
    public GameObject InventoryPanelBT;
    public GameObject ShopPanelBT;
    public GameObject QuestPanelBT;
    public GameObject QuestClosePanelBT;
    public GameObject PausePanelBT;
    public GameObject InfoEquipementBT;
    public GameObject AlchimyPanelBT;
    public GameObject InfoItemBT;
    public GameObject InfoOtherItemBT;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void ChangeFirtsSelect(TypeFirstBT typeFirstBT)
    {
        // Change of the first button selection
        switch (typeFirstBT)
        {
            case TypeFirstBT.PERSOPANEL:    EventSystem.SetSelectedGameObject(PeroPanelBT);       break;
            case TypeFirstBT.INVENTORY:     EventSystem.SetSelectedGameObject(InventoryPanelBT);  break;
            case TypeFirstBT.SHOP:          EventSystem.SetSelectedGameObject(ShopPanelBT);       break;
            case TypeFirstBT.QUEST:         EventSystem.SetSelectedGameObject(QuestPanelBT);      break;
            case TypeFirstBT.CLOSEQUEST:    EventSystem.SetSelectedGameObject(QuestClosePanelBT); break;
            case TypeFirstBT.PAUSE:         EventSystem.SetSelectedGameObject(PausePanelBT);      break;
            case TypeFirstBT.INFOEQUIP:     EventSystem.SetSelectedGameObject(InfoEquipementBT);  break;
            case TypeFirstBT.ALCHIMY:       EventSystem.SetSelectedGameObject(AlchimyPanelBT);    break;
            case TypeFirstBT.INFOITEM:      EventSystem.SetSelectedGameObject(InfoItemBT);        break;
            case TypeFirstBT.INFOOTHERITEM: EventSystem.SetSelectedGameObject(InfoOtherItemBT);   break;
            default:break;
        }
    }
}

