using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TypeLunching { CONTINUE, NEWGAME }
public class LoadGameManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public TypeLunching TypeLunching;

    public void LoadGame()
    {
        if (DataManager.instance.HaveSave())
        {
            SceneManager.LoadScene("MainScene");
            GetComponent<AudioSource>().Stop();
        }

        TypeLunching = TypeLunching.CONTINUE;
    }

    public void NewGame()
    {
        TypeLunching = TypeLunching.NEWGAME;
        SceneManager.LoadScene("MainScene");
        GetComponent<AudioSource>().Stop();
    }

    public void Leave()
    {
        Application.Quit();
    }
}
