using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinManager : MonoBehaviour
{
    public GameObject GameWinPanel;
    public GameObject Player;

    public Text Timer;
    public Text Level;

    private float timer;
    private int secondes;
    private int minutes;

    public static GameWinManager instance;

    private void Awake()
    {
        // make a singelton
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Update()
    {
        // display the game information
        Timer.text = "Temps de jeu : Minutes " + minutes.ToString() + " secondes " + secondes.ToString();
        if (Player.GetComponent<XPmanager>() != null)
            Level.text = "Niveaux du joueur : " + Player.GetComponent<XPmanager>().Level.ToString();

        // calcul the game timer
        timer += Time.deltaTime;
        secondes = (int)timer;
        if (secondes >= 60)
        {
            timer = 0f;
            secondes = 0;
            minutes++;
        }

        // if the game win panel is here
        if (GameWinPanel.activeSelf)
            // Pause the game
            Time.timeScale = 0f;
        else
            // continue 
            Time.timeScale = 1f;
    }

    public void LaunchGameWin()
    {
        // active the Game win panel
        GameWinPanel.SetActive(true);
    }

    public void GoCredit()
    {
        // load the crédit scene
        SceneManager.LoadScene("mainCredit");
    }
}
