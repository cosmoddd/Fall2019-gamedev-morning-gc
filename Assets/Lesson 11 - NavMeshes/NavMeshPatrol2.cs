using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrol2 : MonoBehaviour
{

    public Transform[] wayPoints;
    public int currentWayPoint = 0;
    NavMeshAgent myAgent;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();

        GotoNextWaypoint();
    }

    void GotoNextWaypoint()
    {
        // returns if no points have been set up.
        // YOU BETTER SET THEM UP!
        if (wayPoints.Length == 0)
        {
            return;
        }

        // Set the agent to go to the current waypoint.

        myAgent.destination = wayPoints[currentWayPoint].position;

        // choose the next waypoint destination,
        currentWayPoint = (currentWayPoint + 1);

        // ...cycling to start if necessary
        if (currentWayPoint >= wayPoints.Length)
        {
            currentWayPoint = 0;
        }

    }

    void Update()
    {

        // Choose next destination when the agent gets close to the current target!
        if (myAgent.pathPending == false && // is agent figuring out path (under the hood stuff)
            myAgent.remainingDistance < .3f)// & is agent .3f close to the destination?
            {
                GotoNextWaypoint();
            }

    }
}
