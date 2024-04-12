using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathguard : MonoBehaviour
{   
    public bool IsGuardDead;
    public bool IsGameOver;

    public int Type;
    public int HP;

    public GameObject BackGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(IsGameOver)
        {
            BackGround.SetActive(true);
        }
    }
}
