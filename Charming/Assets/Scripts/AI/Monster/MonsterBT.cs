using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class MonsterBT : TreeBuild
{
    public Transform User;
    public Transform[] waypoints;
    

    public static float speed = 6.0f;

    

    
    protected override Nodes SetupTree()
    {
        Nodes root = new Selector(new List<Nodes>
        {
            

             new Sequence(new List<Nodes>

             {
                 new PlayerInFOVMonster(User),
                 new GoAttackTargetMonster(User)


             }),


            new PatrolMonster (User,waypoints)

        }) ; 

        return root;
    }


}
