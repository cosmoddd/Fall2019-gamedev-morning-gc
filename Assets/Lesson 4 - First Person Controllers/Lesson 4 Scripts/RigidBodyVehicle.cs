using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyVehicle : MonoBehaviour
{
        // 1 declare the rigidbody
    public Rigidbody thisRigidbody; // i like making it public so you can get visual feedback


        // these will come later
    public float thrustSpeed = 2f;
    public float torqueSpeed = 4f;
    public float speedLimit = 10f;

    void Start()
    {
        // 2 get it in the Start() function.
        thisRigidbody = GetComponent<Rigidbody>();
    }


        // 3 declare input vector - for Physics Movement!
    public Vector2 inputVector;


    void Update()
    {
        // 4 get conventional inputs in the update function
            // Input.GetAxis() returns a float between -1f and 1f, and 0 if nothing is happening
	    	// horizontal = A/D, Left/Right... Left = -1f, Right = +1f
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");     
    }

        //  5 FixedUpdate runs every physics frame.  Where the physics magic / madness happens.
    void FixedUpdate()
    {
             // 8 add a magnitude check - can't go too fast!~
        if (thisRigidbody.velocity.magnitude < speedLimit) // how fast are we going? if too fast, don't speed up
        {
            // 6 add forward and backward thrust using AddForce on Y.  Impulse modes apply the force in different ways.
        thisRigidbody.AddForce(transform.forward * inputVector.y * thrustSpeed, ForceMode.Impulse);
                                // (0, 0, 1)
            //(don't forget to freeze the x)
        }
        
            // 7 add torque on the horizontal
        thisRigidbody.AddTorque(transform.up * inputVector.x*torqueSpeed, ForceMode.Impulse);
    }
}
