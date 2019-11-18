using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshClick : MonoBehaviour
{

    NavMeshAgent thisAgent;
    public GameObject navigationPointer;

    public Animator myAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit myHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out myHit, 1000f))
            {
                thisAgent.destination = myHit.point;

                  // set position of helper plus offset
                navigationPointer.transform.position = (myHit.point + new Vector3(0,.1f,0));
                
                myAnimator.SetTrigger("Do Something,Luke");

            }
        }
        if (thisAgent.velocity.magnitude <= .1f)
        {
            myAnimator.SetBool("Luke Is Walking", false);
        }

        if (thisAgent.velocity.magnitude > .1f)
        {
            myAnimator.SetBool("Luke Is Walking", true);
        }

        
    }
}
