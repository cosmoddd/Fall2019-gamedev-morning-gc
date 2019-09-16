using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWalker : MonoBehaviour
{
    
    public List<Dog> dogs;

    void OnEnable()
    {
        for (int i = 0; i< dogs.Count; i++)
        { 
            dogs[i].WoofWoof += OwnerCalls;
        }
    }

    void OnDisable()
    {
        for (int i = 0; i< dogs.Count; i++)
        { 
            dogs[i].WoofWoof -= OwnerCalls;
        }
    }

    void OwnerCalls(string s)
    {

        print("The owner calls out to "+ s);

    }
}
