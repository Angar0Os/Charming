using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class PlayerInFOVMonster : Nodes
{
    private Transform _transform;
    private Transform _player;

    private bool isInit = false;

    GameObject[] users;
    public PlayerInFOVMonster(Transform transform)
    {
        _transform = transform;
    }

    public override NodesState Evaluate()
    {
        
        if (!isInit)  // For search all object with tag player
        {
            users = GameObject.FindGameObjectsWithTag("Player");
            isInit = true;
        }
        ClearData("target"); 

        foreach (GameObject user in users) 
        {
            if (user != _transform.gameObject) 
            {
                if (user.activeSelf == true)

                    if (Vector2.Distance(user.transform.position, _transform.position) < 10) 
                    {
                        Vector2 dir = user.transform.position + _transform.position; // Calculate vector from the player and the guard
                        float angle = Vector2.Angle(dir, _transform.forward); // Calculate angle in the forward of the guard
                        
                        if (angle < 60)
                        {
                            SetData("target", user.transform);
                            
                            return NodesState.SUCCESS;
                           
                        }
                        _transform.gameObject.GetComponent<DirectionStorage>().direction = dir;
                    }
            }
        }
        return NodesState.FAILURE;
    }
}
