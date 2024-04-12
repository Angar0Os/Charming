using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematique1 : MonoBehaviour
{
    public GameObject LastRoom;
    public GameObject NewRoom;
    public GameObject Player;

    public GameObject King;
    public GameObject Prince;
    public GameObject Door;

    public GameObject Princess_Pos;

    public GameObject TriggerThroneDoor;

    public GameObject Prince_Audio;

    public bool EndHappening;

    public Cinemachine.CinemachineVirtualCamera VirtualCamera;

    [Header("First dialogue")]
    public List<string> Name1;
    public List<string> Dialogue1;
    public List<Texture> Character1;
    public List<AudioClip> Son1;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LastRoom.SetActive(false);
        NewRoom.SetActive(true);

        VirtualCamera.enabled = false;
        BlackScreen.instance.IsBlacks = TpPlayer;
        BlackScreen.instance.BlackScreens();

        Cinematique();

        TriggerThroneDoor.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void TpPlayer()
    {
        Player.transform.position = Princess_Pos.transform.position;
        VirtualCamera.enabled = true;
    }

    private void Cinematique()
    {
        King.SetActive(true);
        Prince.SetActive(true);

        Player.GetComponent<AudioSource>().volume = 0;
        Dialogue.instance.NewDialogue(Dialogue1, Name1, Character1, Son1);
        Dialogue.instance.DialogueEnd = ResetVolume;
        Door.GetComponent<Quest1>().enabled = true;
    }

    private void ResetVolume()
    {
        Player.GetComponent<AudioSource>().volume = 1;
    }
}
