using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance;


    public Gamestate GameState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //ChangeState(Gamestate.GenerateGrid);
    }

    public void ChangeState(Gamestate newState)
    {
        GameState = newState;
        switch (newState)
        {
            case FightManager.Gamestate.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case FightManager.Gamestate.SpawnPrincess:
                UnitManager.Instance.SpawnPrincess();
                break;
            case FightManager.Gamestate.SpawnEnnemies:
                UnitManager.Instance.SpawnEnnemies();
                break;
            case FightManager.Gamestate.PrincessTurn:
                break;
            case FightManager.Gamestate.EnnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public enum Gamestate
    {
        GenerateGrid = 0,
        SpawnPrincess = 1,
        SpawnEnnemies = 2,
        PrincessTurn = 3,
        EnnemiesTurn = 4
    }
}
