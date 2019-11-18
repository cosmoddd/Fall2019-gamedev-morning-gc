using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshClick : MonoBehaviour
{
    NavMeshAgent thisAgent;
    public GameObject navigationPointer;

    void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit myHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out myHit, 1000f))
            {
                thisAgent.destination = myHit.point;

                navigationPointer.transform.position = myHit.point;
            }
        }
    }
}
