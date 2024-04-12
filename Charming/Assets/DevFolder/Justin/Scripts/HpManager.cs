using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    public int currentHp;
    public int armor;
    bool damaged;
    AttackManager attackManager;
    
    public void Awake()
    {
        armor = 5;
        currentHp = 10;
        
    }

    public void Update()
    {
        damaged = false;
    }

    public void Takedamage(int amount)
    {
        damaged = true;
        
        currentHp += armor -= amount;      
    }
    public void death()
    {
        if (currentHp <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
