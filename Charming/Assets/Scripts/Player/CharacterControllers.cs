using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllers : MonoBehaviour
{
    public float Speed = 5f;
    Rigidbody2D rb;
    public Vector2 Dir;
    public AnimPlayer _AnimPlayer;
    AudioSource audioSrc;
    bool isMoving = false;
    public bool IsInCastle = true;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
    }
       
    void Update()
    {
        // if the player is not in UI
        if (Dialogue.instance.EndDialogue && !Shop.instance.InShop && !Alchimy.instance.InAlchimy)
        {
            //Detection of the move key


            Dir.x = Input.GetAxisRaw("Horizontal")*Speed;
            Dir.y = Input.GetAxisRaw("Vertical")*Speed;

            if (Dir.x !=0 || Dir.y !=0 ) // Condition for playing stepsound in a loop
        
                isMoving = true;

            else

                isMoving = false;


            if (isMoving)
            {
                if (!audioSrc.isPlaying && IsInCastle)

                    audioSrc.Play();
            }
            else
            {
            audioSrc.Stop();
            }
            
            if(!IsInCastle)
                audioSrc.Stop();
        

        }
        else
        {
            Dir = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        //Calculation of the displacement
        rb.MovePosition(rb.position + Dir * Time.fixedDeltaTime);
        
            
    }





}
