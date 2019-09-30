using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGrounded : MonoBehaviour
{

    public float myRayDistance = .6f;

    // 0)  Raycasting is happening in realtime, no physics, so we call it in the Update() function.
    void Update()
    {
        // 1) Declare your ray!

        Ray myRay = new Ray(transform.position, Vector3.down);

        // 2) Declare the distance of the ray.

        // myRayDistance = .6f; // for our purposes, a little more than half the height.

        // 3)  (OPTIONAL) Get a preview of the cool ray.

        // myRay.origin... starts from the origin of the ray
        // Vector3.down * myRayDistance... points the ray in the desired direction, times the distance.
        // Color... draws the color!
        Debug.DrawRay (myRay.origin, myRay.direction * myRayDistance, Color.white);


        // 4)  Shoot the raycast!
        if (Physics.Raycast(myRay, myRayDistance))
        {
            print("THE COW IS ON THE GRASS");
        }


        // NOT ON THE FLOOR - THE COW IS SPINNING... LOOKING FOR SOMETHING.
        else 
        {
            print("THE COW IS AIRBORNE");
            transform.Rotate(0,1f,0);
        }

    }
}
