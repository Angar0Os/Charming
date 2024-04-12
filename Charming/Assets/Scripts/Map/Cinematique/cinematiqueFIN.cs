using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematiqueFIN : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player_Pos;

    public GameObject Prince;
    public GameObject King;

    public GameObject Music_Manager_obj;


    [Header("First dialogue")]
    public List<string> Name1;
    public List<string> Dialogue1;
    public List<Texture> Character1;
    public List<AudioClip> Son1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cinematique();
    }
    public void Cinematique()
    {
        Player.transform.position = Player_Pos.transform.position;
        King.SetActive(true);

        Player.GetComponent<AudioSource>().volume = 0;
        Dialogue.instance.NewDialogue(Dialogue1, Name1, Character1, Son1);
        Dialogue.instance.DialogueEnd = StartCombat;
    }

    public void StartCombat()
    {
        Music_Manager_obj.GetComponent<MusicManager>().FinalFight.GetComponent<AudioSource>().volume = 1;
        Debug.Log("Combat");
    }

    private void ResetSound()
    {
        Music_Manager_obj.GetComponent<MusicManager>().FinalFight.GetComponent<AudioSource>().volume = 0;
    }
}
