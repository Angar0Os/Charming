using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy1 : BaseEnnemy
{
    private GameObject PrincessDress;
    private GameObject VirtualCamera;
    private GameObject DeathGuardManager;

    public bool IsEnemyDead = false;
    // Start is called before the first frame update
    void Start()
    {
        PrincessDress = GameObject.Find("Princess Dress");
        VirtualCamera = GameObject.Find("CM vcam1");
        DeathGuardManager = GameObject.Find("DeathGuardManager");

        health = DeathGuardManager.GetComponent<deathguard>().HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        { 
            VirtualCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = PrincessDress.transform;
            IsEnemyDead = true;            
        }
    }
}
