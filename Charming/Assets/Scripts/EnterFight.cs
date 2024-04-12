using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFight : MonoBehaviour
{
    private GameObject deathGuardManager;
    private GameObject enemy;
    private GameObject PrincessDress;

    public int Enemy_HP;
    private bool collide = false;

    public int GameObject_Type;
    public int Level;

    private void Start()
    {
        PrincessDress = GameObject.Find("Princess Dress");
        deathGuardManager = GameObject.Find("DeathGuardManager");
        enemy = this.gameObject;
        
    }
    // Update is called once per frame
    void Update()   
    {
       

        if (deathGuardManager.GetComponent<deathguard>().IsGuardDead && collide)
        {
            PrincessDress.GetComponent<XPmanager>().Fight_Win = true;
            GameObject.Destroy(enemy);
            collide = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<XPmanager>().Level_Enemies = Level;

            deathGuardManager.GetComponent<deathguard>().HP = Enemy_HP;
            deathGuardManager.GetComponent<deathguard>().Type = GameObject_Type;
            collide = true;
            FightManager.Instance.ChangeState(FightManager.Gamestate.GenerateGrid);
        }
    }
}
