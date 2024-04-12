using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverPanel;

    public AudioSource GameOverSource;
    public AudioClip GameOverClip;

    public static GameOverManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }


    private void Update()
    {

        // if the panel is here
        if (GameOverPanel.activeSelf)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void LaunchGameOver()
    {
        // active the Game over panel
        GameOverPanel.SetActive(true);
        GameOverSource.PlayOneShot(GameOverClip);
        //ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.GAMEOVER);
    }

    public void Continue()
    {
        // disabel the game over panel
        GameOverPanel.SetActive(false);

        // load the game
        DataManager.instance.LoadData();

        // change input manette
        ForInputManette.instance.ChangeFirtsSelect(TypeFirstBT.QUEST);
    }

    public void GoMenu()
    {
        // destroy the launcher
        Destroy(GameObject.FindGameObjectWithTag("Launcher"));

        // load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }

    public void Leave()
    {
        // quit the game
        Application.Quit();
    }
}
