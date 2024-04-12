using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess1 : BasePrincess
{
    public bool IsPrincessDead = false;

    private GameObject PrincessDress;
    private GameObject VirtualCamera;
    private GameObject BackGround;
    // Start is called before the first frame update
    void Start()
    {
        PrincessDress = GameObject.Find("Princess Dress");
        VirtualCamera = GameObject.Find("CM vcam1");
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            VirtualCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = PrincessDress.transform;
            IsPrincessDead=true;
        }
    }
}
