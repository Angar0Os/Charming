using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DressingScript : MonoBehaviour
{

    public GameObject Player;

    private bool intrigger;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E) && intrigger)
        {
            if(Player.GetComponent<AnimPlayer>().armor == 0)
            {
                Player.GetComponent<AnimPlayer>().armor = 1;
            }
            else
            {
                Player.GetComponent<AnimPlayer>().armor = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        intrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        intrigger = false;
    }
}
