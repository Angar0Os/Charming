using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPause;

    public GameObject PausePanel;

    public static PauseManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Update()
    {
        if (Input.GetButtonDown("BTStart") || Input.GetKeyDown(KeyCode.Escape))
        {
            // close all pages and open the pause menu
            isPause = true;
            PersonalPanel.instance.ClosePersonalPanel();
            Shop.instance.CloseShop();
            QuestManager.instance.CloseQuestPanelInformation();
            QuestUI.instance.CloseWindos();
            Alchimy.instance.CloseAlchimy();
            InventoryUI.instance.CloseInfoEquip();
            InventoryUI.instance.CloseItem();
            InventoryUI.instance.CloseOtherItem();
            ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.PAUSE);
        }

        if (isPause)
        {
            // Pause the game   
            Time.timeScale = 0f;
        }
        else
        {
            // restart the game
            Time.timeScale = 1f;
        }

        PausePanel.SetActive(isPause);
    }

    public void Continue()
    {
        // Continue the game
        isPause = false;
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.QUEST);
    }

    public void GoMenu()
    {
        // go back the menu
        Destroy(GameObject.FindGameObjectWithTag("Launcher"));
        SceneManager.LoadScene("MainMenu");
    }

    public void Save()
    {
        // Save the Game
        DataManager.instance.SaveData();
        isPause = false;
    }

    public void Leave()
    {
        // Leave the game
        Application.Quit();
    }
}


