using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this script on a cube called "Fish"
// INTENT: this fish will swim around randomly
public class Fish : MonoBehaviour
{

    public Vector3 destination;
    public float swimSpeed;

    void Update()
    {
        // ALWAYS SWIM TOWARDS YOUR DESINTATION
        transform.position = Vector3.MoveTowards (
                    transform.position,                 // where you are currently
                    destination,                        // where you are going
                    swimSpeed * Time.deltaTime);        // and how fast?

        // DRAW A DEBUG LINE SO WE CAN VISUALLY SEE THE MOVEMENT
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.yellow);

        // IF FISH IS CLOSE ENOUGH TO DESTINATION
        if (Vector3.Distance(transform.position, destination) < .01f)
            {
                // PICK A NEW DESTINATION
                destination = new Vector3 (Random.Range(-10f, 10f),
			                            	Random.Range(-10f, 10f),
                                            Random.Range(-10f, 10f));
            }

        // DON'T DO THIS  (why not?)
        // if (transform == destination)

        // ALWAYS TURN TOWARDS DESTINATION
        transform.LookAt(destination);

        // another way to move the fish:
		// move forward AFTER you look at your destination
		// transform.Translate(0f, 0f, swimSpeed * Time.deltaTime);
        
    }

}
