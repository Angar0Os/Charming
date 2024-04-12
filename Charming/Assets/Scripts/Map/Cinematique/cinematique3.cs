using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematique3 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player_Pos;

    public GameObject Prince;
    public GameObject Guards;

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

    private void Cinematique()
    {
        Player.transform.position = Player_Pos.transform.position;
        Prince.SetActive(true);
        Guards.SetActive(true);

        Music_Manager_obj.GetComponent<MusicManager>().Court.GetComponent<AudioSource>().volume = 0;
        Music_Manager_obj.GetComponent<MusicManager>().Prince.GetComponent<AudioSource>().volume = 1;

        Dialogue.instance.NewDialogue(Dialogue1, Name1, Character1, Son1);
        Dialogue.instance.DialogueEnd = EndCinematique;
    }
    private void StartCombat()
    {
        Music_Manager_obj.GetComponent<MusicManager>().Prince.GetComponent<AudioSource>().volume = 0;
        Music_Manager_obj.GetComponent<MusicManager>().Fight.GetComponent<AudioSource>().volume = 1;
        Debug.Log("Combat");
        //FightManager.Instance.ChangeState(FightManager.Gamestate.GenerateGrid);
    }

    private void ResetSound()
    {
        Music_Manager_obj.GetComponent<MusicManager>().Fight.GetComponent<AudioSource>().volume = 0;
        Music_Manager_obj.GetComponent<MusicManager>().Court.GetComponent<AudioSource>().volume = 1;
    }

    private void EndCinematique()
    {
        Guards.SetActive(false);
        Prince.SetActive(false);
        Music_Manager_obj.GetComponent<MusicManager>().Prince.GetComponent<AudioSource>().volume = 0;
        Music_Manager_obj.GetComponent<MusicManager>().Court.GetComponent<AudioSource>().volume = 1;
    }
}
