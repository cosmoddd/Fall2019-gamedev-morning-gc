using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGrounded2 : MonoBehaviour
{
    public float myRayDistance = 1f;

    void Update()
    {
              // 1 DECLARE MY RAY
              Ray myRay = new Ray(transform.position, Vector3.down);

              Debug.DrawRay (myRay.origin, myRay.direction * myRayDistance, Color.cyan);  


              if (Physics.Raycast(myRay, myRayDistance))
              {
                  print("WE ARE TOUCHING THE GROUND");
              }
            
            else
                {
                    print("WE ARE AIRBORNE");
                    transform.Rotate(0,1f,0);

                }

    }
}
