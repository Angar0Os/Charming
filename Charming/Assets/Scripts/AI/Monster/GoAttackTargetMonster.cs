using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class GoAttackTargetMonster : Nodes
{

    private Transform _transform;

    public GoAttackTargetMonster(Transform transform)
    {
        _transform = transform;
    }

    public override NodesState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        Vector3 oldPos = _transform.position;

        if (Vector2.Distance(_transform.position, target.position) > 0.01f)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, target.position, MonsterBT.speed * Time.deltaTime); // Direction to follow
           
        }

        Vector2 dir = (_transform.position - oldPos);
        _transform.gameObject.GetComponent<DirectionStorage>().direction = dir;

        state = NodesState.RUNNING;
        return state;
    }

}
