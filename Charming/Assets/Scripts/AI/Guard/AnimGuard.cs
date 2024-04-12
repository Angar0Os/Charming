using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AnimGuard : MonoBehaviour
{
    Animator animGuard;
    

    void Start()
    {
        animGuard = GetComponent<Animator>();
    }

    
    void Update()
    {
     
        
        SetParamsGuard();
    }

    public void SetParamsGuard()
    {
        animGuard= GetComponent<Animator>();
       
        
        Vector2 dir = GetComponent<DirectionStorage>().direction;

 
        // Anim Iddle Guard
        if (dir.x==0 && dir.y==0)   

        {
            animGuard.SetInteger("dir", 0);
        }

        // Anim Walk Down Guard
        else if (dir.y < 0)
        {
            animGuard.SetInteger("dir", 2);
        }

        // Anim Walk Right Guard
        else if (dir.x > 0)
        {
            animGuard.SetInteger("dir", 3);
            GetComponent<SpriteRenderer>().flipX=true;
        }

        // Anim Walk Left Guard
        else if (dir.x < 0)
        {
            animGuard.SetInteger("dir", 3);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // Anim Walk Top Guard
        else if (dir.y > 0)
        {
            animGuard.SetInteger("dir", 1);
        }

    }
}
