using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyVehicle2 : MonoBehaviour
{

    public Rigidbody thisRigidbody;

    public Vector2 inputVector;

    public float thrustSpeed = 10;
    public float torqueSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

    }

    void FixedUpdate()
    {
        thisRigidbody.AddForce(transform.forward * inputVector.y * thrustSpeed, ForceMode.Impulse);
  
        thisRigidbody.AddTorque(transform.up * inputVector.x * torqueSpeed, ForceMode.Impulse);
    }
}
