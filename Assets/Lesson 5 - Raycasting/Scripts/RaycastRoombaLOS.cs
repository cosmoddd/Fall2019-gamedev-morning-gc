using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastRoombaLOS : MonoBehaviour
{

    // No need for start function.  We're going right to the source. UDPATE again.
    void Update()
    {
        
        // STEP 1: DEFINE THE RAY

        // revisit the forward function
        // Vector3.forward = world's forward, like "east", never changes
		// transform.forward = this object's forward, changes w/ rotation
        
        Ray mooRay = new Ray (transform.position, transform.forward);

        // STEP 2: DEFINE MAXIMUM RAYCAST DISTANCE
        float maxRayDistance = 1f; // just a bit in front,yeah?

        // STEP 3: VISUALIZE THE RAYCAST
        Debug.DrawRay(mooRay.origin, mooRay.direction * maxRayDistance, Color.white);

        // STEP 4: SHOOT THE RAYCATS AND LET THE COW NAVIGATE THE MAZE.
                    // raycast is currently false.  it's not hitting anything
        if (Physics.Raycast(mooRay, maxRayDistance))                                                                    
        {

            // if the raycast is true, it hits something... a wall in front of us.

            // when that happens... 
            // turning logic takes place
            int randomNumber = Random.Range(0,100); // RNG between 0 and 100 every frame!
            {
                if (randomNumber < 50)
                {
                    // 50% chance of rotating 90 degrees to the left
                    transform.Rotate(0f,-90f,0f);
                }
                else 
                {
                    // 50% chance of rotating 90 degrees to the right
                    transform.Rotate(0f,90f,0f);
                }
            }
        }

        else
        {
			// if raycast is false = nothing in raycast's way
			// so go forward
			transform.Translate(0f, 0f, Time.deltaTime);
		}

    }
}
