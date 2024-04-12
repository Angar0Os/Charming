using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFightManager : MonoBehaviour
{
    public static MenuFightManager Instance;

    [SerializeField] private GameObject selectedPrincessObject, tileObject, tileUnitObject;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            tileObject.SetActive(false);
            tileUnitObject.SetActive(false);
            return;
        }

        tileObject.GetComponentInChildren<Text>().text = tile.TileName;
        tileObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            tileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            tileUnitObject.SetActive(true);
        }
    }

    public void ShowSelectedPrincess(BasePrincess princess)
    {
        if(princess == null)
        {
            selectedPrincessObject.SetActive(false);
            return;
        }

        selectedPrincessObject.GetComponentInChildren<Text>().text = princess.UnitName;
        selectedPrincessObject.SetActive(true);
    }
}
