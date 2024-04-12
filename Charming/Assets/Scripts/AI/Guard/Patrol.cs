using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class Patrol : Nodes
{
    public Transform _user;
    private Transform[] _waypoints; // Create list of waypoint in inspector
   

    public int _currentWaypointIndex = 0;

    private float _waitCounter = 0f;
    private float timerNextPos = 2f;

    private bool _waiting = false;


    public Patrol (Transform user, Transform[] waypoints)
    {
        _user = user;      
        _waypoints = waypoints;
     
        
    }

    public override NodesState Evaluate()
    {

        {
            timerNextPos -= Time.deltaTime;

            if (_waiting)  // Add time for timer to go next waypoint and change boolean _waiting
            {
                _waitCounter += Time.deltaTime;

                if (_waitCounter >= timerNextPos)
                {
                    _waiting = false;
                }
            }

            else

            {
                Transform wp = _waypoints[_currentWaypointIndex];

                Vector3 oldPos = _user.position;
               
                    if (Vector2.Distance(_user.position, wp.position) < 0.01f) // To check the new waypoint
                    {
                        _user.position = wp.position;
                        _waitCounter = 0f;
                        _waiting = true;
                        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                    }

                    else
                    {

                        _user.position = Vector2.MoveTowards(_user.position, // To go to the new waypoint
                            wp.position,
                           GuardBT.Speed * Time.deltaTime);
                    }


                Vector2 dir = (_user.position - oldPos);
                _user.gameObject.GetComponent<DirectionStorage>().direction = dir;
            }

            state = BehaviourTree.NodesState.RUNNING;
            return state;
        } 
       
    }
}
