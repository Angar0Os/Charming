using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class GoAttackTarget : Nodes
{

    private Transform _user;

    public GoAttackTarget(Transform user)
    {
        _user = user;
    }

    public override NodesState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        Vector3 oldPos = _user.position;

        if (Vector2.Distance(_user.position, target.position) > 0.01f)
        {
            _user.position = Vector2.MoveTowards(_user.position, target.position, GuardBT.Speed * Time.deltaTime); // Direction to follow
           
        }
        Vector2 dir = (_user.position - oldPos);
        _user.gameObject.GetComponent<DirectionStorage>().direction = dir;

        state = NodesState.RUNNING;
        return state;
    }

}
