using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHer : MonoBehaviour
{
    public GameObject Restart;
    public GameObject Player;

    public GameObject BedRoom;
    public bool Collide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Collide)
        {
            BedRoom.SetActive(true);
            Player.transform.position = Restart.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<AnimPlayer>())
        {
            Collide = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Collide = false;
    }
}
