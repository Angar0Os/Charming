using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    public int armor = 0;

    Animator anim;
    public CharacterControllers _characterControllers;
  
    void Start()
    {
       
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        SetParamDress();
        SetParamCloak();
        SetParamArmor();
        UpdateAnim();
    }

    public void UpdateAnim()
    {
        if (EquipementManager.instance.Equipements[0] != null)
            armor = EquipementManager.instance.Equipements[0].TypeGarment;
       
    }
    public void SetParamDress()
    {
       // princess dress
        if (armor == 0)
        {
            _characterControllers = GetComponent<CharacterControllers>();
            anim = GetComponent<Animator>();


            //Anim iddle pricess dress
            if (_characterControllers.Dir.x == 0 && _characterControllers.Dir.y == 0)
            {
                anim.SetInteger("dir", 0);
                anim.SetInteger("armor", 0);
            }

            //anim walk down princess dress
            else if (_characterControllers.Dir.y < 0)
            {
                anim.SetInteger("dir", 1);
                anim.SetInteger("armor", 0);
            }
            //anim walk side -> princess dress
            else if (_characterControllers.Dir.x > 0)
            {
                anim.SetInteger("dir", 2);
                anim.SetInteger("armor", 0);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            //anim walk side <- princess dress
            else if (_characterControllers.Dir.x < 0)
            {
                anim.SetInteger("dir", 2);
                anim.SetInteger("armor", 0);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            //anim walk top princess dress
            else if (_characterControllers.Dir.y > 0)
            {
                anim.SetInteger("dir", 3);
                anim.SetInteger("armor", 0);
            }
        }

    }
    public void SetParamCloak()
    {
        // princess with leather outfit
        if (armor == 1)
        {
            _characterControllers = GetComponent<CharacterControllers>();
            anim = GetComponent<Animator>();


            //Anim iddle princess with leather outfit
            if (_characterControllers.Dir.x == 0 && _characterControllers.Dir.y == 0)
            {
                anim.SetInteger("dir", 0);
                anim.SetInteger("armor", 1);
            }

            //anim walk down princess with leather outfit
            else if (_characterControllers.Dir.y < 0)
            {
                anim.SetInteger("dir", 1);
                anim.SetInteger("armor", 1);
            }
            //anim walk side -> princess with leather outfit
            else if (_characterControllers.Dir.x > 0)
            {
                anim.SetInteger("dir", 2);
                anim.SetInteger("armor", 1);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            //anim walk side <- princess with leather outfit
            else if (_characterControllers.Dir.x < 0)
            {
                anim.SetInteger("dir", 2);
                anim.SetInteger("armor", 1);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            //anim walk top princess with leather outfit
            else if (_characterControllers.Dir.y > 0)
            {
                anim.SetInteger("dir", 3);
                anim.SetInteger("armor", 1);
            }
        }

    }

    public void SetParamArmor()
    {
        //princess with plate outfit
        if (armor == 2)
        {
            _characterControllers = GetComponent<CharacterControllers>();
            anim = GetComponent<Animator>();


            //Anim iddle princess with plate outfit
            if (_characterControllers.Dir.x == 0 && _characterControllers.Dir.y == 0)
            {
                anim.SetInteger("dir", 0);
                anim.SetInteger("armor", 2);
            }

            //anim walk down princess with plate outfit
            else if (_characterControllers.Dir.y < 0)
            {
                anim.SetInteger("dir", 1);
                anim.SetInteger("armor", 2);
            }
            //anim walk side -> princess with plate outfit
            else if (_characterControllers.Dir.x > 0)
            {
                anim.SetInteger("dir", 2);
                anim.SetInteger("armor", 2);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            //anim walk side <- princess with plate outfit
            else if (_characterControllers.Dir.x < 0)
            {
                anim.SetInteger("dir", 2);
                anim.SetInteger("armor", 2);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            //anim walk top princess with plate outfit
            else if (_characterControllers.Dir.y > 0)
            {
                anim.SetInteger("dir", 3);
                anim.SetInteger("armor", 2);
            }
        }

    }

}