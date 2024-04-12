using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
  public int attackDamage = 6;

    GameObject player;
    HpManager hpManager;

    float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PrincessPlayer");
        hpManager = player.GetComponent<HpManager>();
    }
    private void clickAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            Debug.Log("AIE");
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
    }

    void Attack()
    {
        timer = 1f;
        if(hpManager.currentHp > 0)
        {
            hpManager.Takedamage(attackDamage);
        }
    }
}
