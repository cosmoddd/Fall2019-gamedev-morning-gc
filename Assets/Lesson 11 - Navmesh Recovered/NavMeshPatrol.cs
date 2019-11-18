using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public int currentWayPoint = 0;
    NavMeshAgent myAgent;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        GoToNextWaypoint();
    }

    void GoToNextWaypoint()
    {
        // if there are no waypoints, exit function
        if (waypoints.Length == 0)
        {
            return;
        }

        // set destination to current waypoint's positon
        myAgent.destination = waypoints[currentWayPoint].position;

        // increment next waypoint
        currentWayPoint = (currentWayPoint + 1);

        // if waypoint pointer exceeds array length, reset to 0
        if (currentWayPoint >= waypoints.Length)
        {
            currentWayPoint = 0;
        }
    }

    void Update()
    {
        if (myAgent.remainingDistance < .3f)
        {
            GoToNextWaypoint();
        }
    }

}
