using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class PlayerInFOV : Nodes
{
    private Transform _user;
  

    private bool isInit = false;

    GameObject[] users;
    public PlayerInFOV(Transform user)
    {
        _user = user;
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
            if (user != _user.gameObject) 
            {
                if (user.activeSelf == true)

                    if (Vector2.Distance(user.transform.position, _user.position) < 10) 
                    {
                        Vector2 dir = user.transform.position + _user.position; // Calculate vector from the player and the guard
                        float angle = Vector2.Angle(dir, _user.forward); // Calculate angle in the forward of the guard
                        
                        if (angle < 60)
                        {
                            SetData("target", user.transform);
                            
                            return NodesState.SUCCESS;
                           
                        }

                        _user.gameObject.GetComponent<DirectionStorage>().direction = dir;
                    }
                
            }
        }
        return NodesState.FAILURE;
    }
}
