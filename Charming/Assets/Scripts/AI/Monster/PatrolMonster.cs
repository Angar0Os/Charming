using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class PatrolMonster : Nodes
{
    private Transform _transform;
    private Transform[] _waypoints; // Create list of waypoint in inspector

    private int _currentWaypointIndex = 0;

    private float _waitCounter = 0f;
    private float timerNextPos = 2f;

    private bool _waiting = false;


    public PatrolMonster (Transform transform, Transform[] waypoints)
    {
        _transform = transform;
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
                Vector3 oldPos = _transform.position;

                if (Vector2.Distance(_transform.position, wp.position) < 0.01f) // To check the new waypoint
                {
                    _transform.position = wp.position;
                    _waitCounter = 0f;
                    _waiting = true;
                    _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                }

                else
                {
                    _transform.position = Vector2.MoveTowards(_transform.position, // To go to the new waypoint
                        wp.position,
                       MonsterBT.speed * Time.deltaTime);


                }

                Vector2 dir = (_transform.position - oldPos);
                _transform.gameObject.GetComponent<DirectionStorage>().direction = dir;

            }

            state = BehaviourTree.NodesState.RUNNING;
            return state;
        } 
       
    }
}
