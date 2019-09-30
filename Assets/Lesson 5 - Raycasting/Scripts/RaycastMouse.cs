using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on your Main Camera (+ make sure it's tagged as MainCamera)
// intent: move a sphere around based on mouse cursor raycast

public class RaycastMouse : MonoBehaviour
{

    // 1  Define Prefab
    public GameObject prefabBrush;

    // once again... update only
    void Update()
    {
        // STEP 1: DEFINE THE RAY
            // screenpoint to ray is ESSENTIAL FOR DOING RAYCASTING WITH A MOUSE

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);   // standard implementation of the technique

        // STEP 2: DEFINE MAXIMUM RAYCAST DISTANCE
        float maxRaycastDistance = 1000f;  // just a big number to catch whatever

        // STEP 3: VISUALIZE THE RAYCAST AGAIN
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * maxRaycastDistance, Color.magenta);

        // let's demonstrate it

        // STEP 4: Declare the raycast hit.
        RaycastHit mouseHit = new RaycastHit();

        // STEP 5: shoot the raycast!!
        if (Physics.Raycast(mouseRay, out mouseHit, maxRaycastDistance))
        {
                // out RaycastHit is incredible powerful... it allows us to use any ray to access 
                // information about any other object in the scene
                //... just make sure the objects you want to access have colliders!

                // STEP 6
                // if true, if we hit the wall, move the prefab 'brush' there
                prefabBrush.transform.position = mouseHit.point;
        
                // STEP 7
                // what if we wanted the tag of the thing we hit?
                Debug.Log(mouseHit.transform.tag);


                // STEP 8
                // INSTANTIATION: cloning an object during the game
                // myRayHit.point = the position of the new clone
                // Quaternion.Euler() = the rotation of the new clone



                if (Input.GetMouseButton(0)) // 0 = left-click
                {
                    // (ALSO STEP 10)
                    GameObject instantiatedPaint;

                    // do this first
                    instantiatedPaint = Instantiate(prefabBrush, mouseHit.point, Quaternion.Euler(0, 0, 0));
    
                    // STEP 10  finally... what if we want to attach the new newly spawned object to the thing we hit?
                    instantiatedPaint.transform.SetParent(mouseHit.transform);
                }

                // STEP 9  what if we wanted to MANIPULATE the object we hit?
                mouseHit.transform.Rotate(0, 1f, 0f); // demo: rotate the thing we hit

        }

    }
}
