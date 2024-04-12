using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;

    private GameObject princessDress;

    public int Damage_Player;
    public int Defense_Player;

    public int health;

    private void Start()
    {
        princessDress = GameObject.Find("Princess Dress");    
    }
    private void Update()
    {
        Damage_Player = princessDress.GetComponent<PersonalPanel>().Attack;
        Defense_Player = princessDress.GetComponent<PersonalPanel>().Defence;
    }
    public void Damage(int dmg)
    {

        health -= dmg;
    }

    private void Death()
    {
    }
}
