using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPmanager : MonoBehaviour
{
    public Slider XpSlider;
    public Text LevelPanel;

    public GameObject DeathGuardManager;

    public int Xp;
    public int Xp_Win;
    public int Xp_Max;
    public int Xp_Min = 0;
    public int Level = 1;
    public int Level_Enemies;
    public bool Fight_Win = false;
    

    private void Start()
    {
       
    }

    void Update()
    {

        LevelPanel.text = "Level " + Level.ToString();

        XpSlider.maxValue = Xp_Max;
        XpSlider.value = Xp;

        XpToLvlUp();
        XpDrop();
        Leveling();
    }


    //Xp to level up
    void XpToLvlUp()
    {
        if(Level == 1)
            Xp_Max = 100;
        if (Level == 2)
            Xp_Max = 150;
        if (Level == 3)
            Xp_Max = 200;
        if (Level == 4)
            Xp_Max = 300;
        if (Level == 5)
            Xp_Max = 400;
        if (Level == 6)
            Xp_Max = 500;
        if (Level == 7)
            Xp_Max = 600;
        if (Level == 8)
            Xp_Max = 700;
        if (Level == 9)
            Xp_Max = 800;
        if (Level == 10)
            Xp_Max = 1000;        

    }

    //Xp Wins by combat
    void XpDrop()
    {
        if (Level_Enemies == 1)
            Xp_Win = 20;
        if (Level_Enemies == 2)
            Xp_Win = 30;
        if (Level_Enemies == 3)
            Xp_Win = 50;
        if (Level_Enemies == 4)
            Xp_Win = 70;
        if (Level_Enemies == 5)
            Xp_Win = 80;
        if (Level_Enemies == 6)
            Xp_Win = 90;
        if (Level_Enemies == 7)
            Xp_Win = 95;
        if (Level_Enemies == 8)
            Xp_Win = 100;
        if (Level_Enemies == 9)
            Xp_Win = 110;
        if (Level_Enemies == 10)
            Xp_Win = 120;
    }

    //calculation of remaining xp for leveling up
    void Leveling()
    {
        if(Fight_Win == true)
        {
            Xp = Xp + Xp_Win;
            Fight_Win = false;
        }
        else
        {
            Xp_Win = 0;
        }

        if(Xp >= Xp_Max)
        {
            Level++;
            PersonalPanel.instance.GivePoints(5);
            Xp = Xp_Min;
        }
        else
        {
            Xp_Win = 0;
        }
    }

}
