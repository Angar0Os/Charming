using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematique4 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player_Pos;

    public GameObject Prince;

    public GameObject Music_Manager_Obj;


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
        Prince.SetActive(true);

        Music_Manager_Obj.GetComponent<MusicManager>().Forest.GetComponent<AudioSource>().volume = 0;
        Music_Manager_Obj.GetComponent<MusicManager>().Prince.GetComponent<AudioSource>().volume = 1;
        Dialogue.instance.NewDialogue(Dialogue1, Name1, Character1, Son1);
        Dialogue.instance.DialogueEnd = StartCombat;
    }

    private void StartCombat()
    {
        Music_Manager_Obj.GetComponent<MusicManager>().Prince.GetComponent<AudioSource>().volume = 0;
        Music_Manager_Obj.GetComponent<MusicManager>().Fight.GetComponent<AudioSource>().volume = 1;
        Debug.Log("Combat");
    }

    private void ResetSound()
    {
        Music_Manager_Obj.GetComponent<MusicManager>().Fight.GetComponent<AudioSource>().volume = 0;
        Music_Manager_Obj.GetComponent<MusicManager>().Forest.GetComponent <AudioSource>().volume = 1;

    }
}
