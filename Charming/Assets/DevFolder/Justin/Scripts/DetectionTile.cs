using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionTile : MonoBehaviour
{
    private void Update()
    {
        if(FightManager.Instance.GameState == FightManager.Gamestate.EnnemiesTurn)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(FightManager.Instance.GameState == FightManager.Gamestate.PrincessTurn)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}

