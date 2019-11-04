using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCode : MonoBehaviour
{
    public Camera thisCamera;
    public Texture2D cursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private float defaultY = .5f;

    public Vector3 targetPos;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        Cursor.visible = true;
        Cursor.SetCursor(cursor, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rcDist = 1000f;
        Debug.DrawRay (mouseRay.origin, mouseRay.direction * rcDist, Color.red);
        RaycastHit mouseHit = new RaycastHit();

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(mouseRay, out mouseHit, rcDist))
            {
                targetPos = mouseHit.point;
                targetPos.y = defaultY;
                // target.position= targetPos;

                if ((Vector3)transform.position != targetPos)
                {
                    transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
                }
            }
        }
    }
}
