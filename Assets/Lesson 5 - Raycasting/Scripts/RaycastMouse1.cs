using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMouse1 : MonoBehaviour
{

    public GameObject prefabBrush;

    void Update()
    {
        // STEP 1: DEFINE THE RAY
        // SCREENPOINT TO RAY IS THE TECHNIQUE

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); // standard implementation of the technique

        // STEP 2: DEFINE MAX RAYCAST DISTANE
        float maxRaycastDistance = 1000f; // just a big number to catch whatever

        // STEP 3: VISUALIZE THE RAYCAST AGAIN
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * maxRaycastDistance, Color.red);

        // let's do something with this

        // STEP 4: Declare the racyast hit.
        RaycastHit mouseHit = new RaycastHit();

        // STEP 5: shoot the raycast!!!!!
        if (Physics.Raycast(mouseRay, out mouseHit, maxRaycastDistance))
        {
            // STEP 6: if true... if we hit the canas... move the prefab 'brush' to wher the pointer is

            prefabBrush.transform.position = mouseHit.point;

            // STEP 7: WHAT IF WE WANT THE TAG of the thing that we hit?
            Debug.Log(mouseHit.transform.tag);

            // STEP 8:  CLone an object during the game
            if (Input.GetMouseButton(0))
            {
                GameObject instantiatedPaint;
                instantiatedPaint = Instantiate(prefabBrush, mouseHit.point, Quaternion.Euler(0,0,0));
            
            // STEP 10 set new parent for paint
                instantiatedPaint.transform.SetParent(mouseHit.transform);
            }

            // STEP 9 what if we want to Manipulate the object we hit?
            mouseHit.transform.Rotate(0,1,0);

        }
    }
}
