using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameObject Court;
    public GameObject Tavern;
    public GameObject GameOver;
    public GameObject Forest;
    public GameObject Field;
    public GameObject Prince;
    public GameObject Fin;
    public GameObject Fight;
    public GameObject FinalFight;

    private void Start()
    {
        Court.GetComponent<AudioSource>().Play();
        Tavern.GetComponent<AudioSource>().Play();
        GameOver.GetComponent<AudioSource>().Play();
        Forest.GetComponent<AudioSource>().Play();
        Field.GetComponent<AudioSource>().Play();
        Prince.GetComponent<AudioSource>().Play();
        Fin.GetComponent<AudioSource>().Play();
        Fight.GetComponent<AudioSource>().Play();
        FinalFight.GetComponent<AudioSource>().Play();
    }
}
