using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class GuardBT : TreeBuild
{
    public Transform _user;
    public Transform[] waypoints;
    public static float Speed = 5.5f;
    

    
    protected override Nodes SetupTree()
    {
        Nodes root = new Selector(new List<Nodes>
        {
            

             new Sequence(new List<Nodes>

             {
                 new PlayerInFOV(_user),
                 new GoAttackTarget(_user)


             }),


            new Patrol (_user,waypoints)

        }) ; 

        return root;
    }

}
