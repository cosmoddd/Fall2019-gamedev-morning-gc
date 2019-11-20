using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  // this allows use to use navmesh

public class NavMeshMove2 : MonoBehaviour
{

    public Transform goal;
    public NavMeshAgent  thisAgent;

    // Start is called before the first frame update
    void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        thisAgent.destination = goal.position;
    }

}
