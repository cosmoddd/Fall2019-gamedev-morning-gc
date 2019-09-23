using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnabler : MonoBehaviour
{
    public GameObject myCamera;

    void OnTriggerEnter()
    {
        print("SOMETHING ENTERED!");
        myCamera.SetActive(true);
    }
}
