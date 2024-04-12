using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOrLoad : MonoBehaviour
{
    private void Start()
    {

        LoadGameManager launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<LoadGameManager>();

        if (launcher != null)
        {
            // if i want continue the game
            if (launcher.TypeLunching == TypeLunching.CONTINUE)
            {
                // if i have a save
                if (DataManager.instance.HaveSave())
                {
                    // load the save 
                    DataManager.instance.LoadData();
                }
            }
            // if i want Make a new game
            else if (launcher.TypeLunching == TypeLunching.NEWGAME)
            {
                // reset data
                DataManager.instance.ResetPlayerData();
            }
        }
    }
}
