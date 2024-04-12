using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpScript : MonoBehaviour
{

    public GameObject LastRoom;
    public GameObject NewRoom;
    private GameObject Player;

    public AudioSource Last_AudioSource;
    public AudioSource New_AudioSource;

    public AudioClip New_AudioClip;
    public bool isPlaying = false;

    public Vector2 NewPlayerPos;
    public Cinemachine.CinemachineVirtualCamera VirtualCamera;
    public static DataManager instance;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Princess Dress");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LastRoom.SetActive(false);
        NewRoom.SetActive(true);
        

        VirtualCamera.enabled = false;
        BlackScreen.instance.IsBlacks = TpPlayer;
        BlackScreen.instance.BlackScreens();

        Player.GetComponent<CharacterControllers>().IsInCastle = false;

        Player.GetComponent<CharacterControllers>().IsInCastle = true;

        Last_AudioSource.volume = 0;
        New_AudioSource.volume = 1;


    }

    private void TpPlayer()
    {
        Player.transform.position = NewPlayerPos;
        VirtualCamera.enabled = true;
        DataManager.instance.SaveData();
    }
}
