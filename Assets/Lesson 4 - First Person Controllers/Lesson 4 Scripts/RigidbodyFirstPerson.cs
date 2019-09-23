using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyFirstPerson : MonoBehaviour
{

         // SETUP

        // 1   make a move speed.  
    public float moveSpeed = 1f;

        // 2   make a vector 3 that we'll pass to the physics
    public Vector3 inputVector;

        // 3  make the rigidbody
    public Rigidbody thisRigidbody;

        // 4  get the rigidbody in the script
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

        // 5  in Update()... get the inputs!

    public float mouseX;
    public float mouseY;

    void Update()
    {
            // 6 MOUSE LOOK FIRST
            //  GET DELTAS.  DETLA = DIFFERENT.  DIFFERENCE BETWEEN ONE FRAME TO THE NEXT
            //  0 MEANS NOTHING IS MOVING.  ANTYING ELSE MEANS IT IS.  NOT POSITOINS
        mouseX = Input.GetAxis("Mouse X"); // horizontal mouse movement
        mouseY = Input.GetAxis("Mouse Y"); // vertical mouse movement


            // 7 GET / SET ROTATIONS
            // rotations: Pitch Yaw Roll
            // pitch = up/down rotation, X axis
            // yaw = left/right rotation, Y axis
            // roll = rolling motion, Z axis (we're not doing any roll tbh)

        transform.Rotate(0, mouseX, 0); // yaw
        Camera.main.transform.Rotate(-mouseY, 0, 0);    // pitch (only moves the camera, not the attached capsule)

            // 8 GET WASD MOVEMENT
            // GetAxis usually returns a float between -1f and 1f
            // when you're not pressing anything, it returns ~0f
		float horizontal = Input.GetAxis("Horizontal"); // A/D, Left/Right
		float vertical = Input.GetAxis("Vertical"); // W/S, Up/Down, Forward

            // 9 the bad way...
            // apply keyboard input to position
            // when you do movement via "transform", you are teleporting it
            
            //transform.position += transform.forward * vertical * moveSpeed; // forward
            //transform.position += transform.right * horizontal * moveSpeed; // strafe
            
            // this method has NO COLLISION DETECTION ^

            // 10 so, let's do this the better way...
		inputVector = transform.forward * vertical; // forward
		inputVector += transform.right * horizontal; // strafe
    
    }

        // 11  it runs every physics frame (a different framerate than input or rendering)
        // all your physics code should go in FixedUpdate
	void FixedUpdate()
	{
		// override object's velocity with desired inputVector direction
        // some physics math to simulate the gravity, speed, etc...
		thisRigidbody.velocity = inputVector * moveSpeed + Physics.gravity * 0.69f;
		
	}

}
