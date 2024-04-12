using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickUp : MonoBehaviour
{
    private GameObject player;
    public bool ChestIsOpen = false;

    Animator anim;

    public Items Items;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        anim.SetBool("IsOpen", false);
    }

    void Update()
    {

        //Trunk opening
        if (Input.GetKey(KeyCode.E))
        {
            if (ChestIsOpen == false)
            {
                if (Vector2.Distance(transform.position, player.transform.position) < 3.5f)
                {
                    anim.SetBool("IsOpen", true);
                    PickUp();
                    ChestIsOpen = true;
                }
            }
        }
        //trunk animation
        if (ChestIsOpen == true)
        {
            anim.SetBool("IsOpen", true);
        }
    }


    //adding equipment to the trunk
    private void PickUp()
    {
        bool isPickUp = Inventory.instance.Add(this.Items);
        

    }
}
