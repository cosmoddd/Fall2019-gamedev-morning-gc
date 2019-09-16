using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public delegate void DogDelegate(string s);
    public event DogDelegate WoofWoof;

    public string dogName;
    public float dogTime;


    void Start()
    {
        DogTime();
    }

    void DogTime()
    {
        StartCoroutine(DogLeash());
    }

    IEnumerator DogLeash()
    {
        yield return new WaitForSeconds(dogTime);
        WoofWoof?.Invoke(dogName);  
        yield return new WaitForSeconds(1);
        WoofWoof?.Invoke(dogName);  
    }

}
