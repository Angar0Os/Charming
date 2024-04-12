using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager instance;

    public int Coins;

    public Text CoinsLabelInventory;
    public Text CoinsLabelShop;

    private void Start()
    {
        updateUI();
    }

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void IncrementCoins(int value)
    {
        // money increment
        Coins += value;
        updateUI();
    }

    private void updateUI()
    {
        // upadte the Coins value in UI
        CoinsLabelInventory.text = Coins.ToString();
        CoinsLabelShop.text = Coins.ToString();
    }
}
