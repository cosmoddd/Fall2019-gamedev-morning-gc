using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastRoombaLOS1 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // STEP 1: DEFINE THE RAY

        Ray cowRay = new Ray(transform.position, transform.forward);

        // STEP 2: DEFINE MAXIMUM RAYCAST DISTANCE
        float maxRayDistance = 1f; // just a bit in front

        // STEP 3: VISUALIZE IT AGAIN
        Debug.DrawRay(cowRay.origin, cowRay.direction * maxRayDistance, Color.red);

        // STEP 4: SHOOT THE RAY AND LET THE COW NAVIGATE THE MAZE
        // racyast is currently false.  it's not hitting anything

        if (Physics.Raycast(cowRay, maxRayDistance))
        {
            // if the raycast is true, it hits something... a wall in front of us.

            // when that happens..
            // turning logic takes place

            int randomNumber = Random.Range(0,100);  // RNG BETWEEN 0 AND 100
            {
                if (randomNumber < 50)
                {
                    // 50% chance that it will rotate 90 degrees to the left
                    transform.Rotate(0f,-90f, 0f);
                }
                else 
                {
                    transform.Rotate(0f, 90f,0f);
                }
            }
        }

        else
        {
            transform.Translate(0f,0f, 1 * Time.deltaTime);
        }

    }
}
