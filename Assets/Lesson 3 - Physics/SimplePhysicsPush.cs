using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePhysicsPush : MonoBehaviour
{

    public float forcePower = 10f;
    Rigidbody thisRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            thisRigidbody.AddForce(Vector3.forward * forcePower);
        }
    }
}
