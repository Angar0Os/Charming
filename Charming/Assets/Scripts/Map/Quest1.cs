using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
    public GameObject Player;

    public GameObject Disable_guard;

    //Disabled guard 
    public GameObject DGuard;

    //Enabled guard
    public GameObject Guard;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(Player.GetComponent<AnimPlayer>().armor == 1)
            {
                ActiveQuest1();
            }
    }

    private void ActiveQuest1()
    {
        Disable_guard.SetActive(false);
        Guard.SetActive(true);
        DGuard.SetActive(false);

    }
}
