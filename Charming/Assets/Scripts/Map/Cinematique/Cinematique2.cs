using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematique2 : MonoBehaviour
{

    private bool CanDoEvent;

    public GameObject Princess_Dress;
    public GameObject Position_Princess_Event;

    public GameObject Prince;

    public GameObject Music_Manager_obj;
    private GameObject DeathGuardManager;
    public GameObject Guards;

    [Header("First dialogue")]
    public List<string> Name1;
    public List<string> Dialogue1;
    public List<Texture> Character1;
    public List<AudioClip> Son1;

    [Header("Second dialogue")]
    public List<string> Name2;
    public List<string> Dialogue2;
    public List<Texture> Character2;
    public List<AudioClip> Son2;

    public bool DoOnce = true;

    private void Start()
    {
        DeathGuardManager = GameObject.Find("DeathGuardManager");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Cinematique();
    }

    private void Cinematique()
    {
        Princess_Dress.transform.position = Position_Princess_Event.transform.position;
        Prince.SetActive(true);
        Guards.SetActive(true);
        Princess_Dress.GetComponent<AudioSource>().volume = 0;
        Music_Manager_obj.GetComponent<MusicManager>().Prince.GetComponent<AudioSource>().volume = 1;
        Dialogue.instance.NewDialogue(Dialogue1, Name1, Character1, Son1);
        Dialogue.instance.DialogueEnd = EndCinematique;

    }

    private void StartCombat()
    {
        Dialogue.instance.NewDialogue(Dialogue2, Name2, Character2, Son2);
        Music_Manager_obj.GetComponent<MusicManager>().Fight.GetComponent<AudioSource>().volume = 1;
        Music_Manager_obj.GetComponent<MusicManager>().Prince.GetComponent<AudioSource>().volume = 0;

        //FightManager.Instance.ChangeState(FightManager.Gamestate.GenerateGrid);
    }

    private void EndCinematique()
    {
        Music_Manager_obj.GetComponent<MusicManager>().Prince.GetComponent<AudioSource>().volume = 0f;
        Music_Manager_obj.GetComponent<MusicManager>().Fight.GetComponent<AudioSource>().volume = 0f;
        Princess_Dress.GetComponent<AudioSource>().volume = 1;
        Prince.SetActive(false);
        Guards.SetActive(false);
    }
}
