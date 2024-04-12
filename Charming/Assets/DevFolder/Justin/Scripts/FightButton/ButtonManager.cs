using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    public Button button;
    public int choicePrincessAction;

    void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
      switch(choicePrincessAction)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }


        //if(FightManager.Instance.GameState == FightManager.Gamestate.EnnemiesTurn)
        //{
        //    choicePrincessAction = 0;
        //}
    }

   


    public void PrincessMovement()
    {
        if(choicePrincessAction == 0)
        { 
            choicePrincessAction = 1; 
        }
        
        
    }

    public void PrincessAttack()
    {
        if (choicePrincessAction == 0)
        { 
            choicePrincessAction = 2; 
        }
        
    }

    public void PrincessAttack2()
    {
        if (choicePrincessAction == 0)
        {
            choicePrincessAction = 3; 
        }
        
    }

    public void BackToActionChoice()
    {
        choicePrincessAction = 0;
    }
}
