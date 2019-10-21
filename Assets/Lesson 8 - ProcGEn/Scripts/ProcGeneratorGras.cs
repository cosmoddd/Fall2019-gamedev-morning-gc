using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGeneratorGras : MonoBehaviour
{

    // THE BLADE OF GRASS WE'LL BE CLONING.  ASSIGN IN INSPECTOR!
    public GameObject gameGrassPrefab;

    public int grassMax = 200;


    void Start()
    {
        // int grassCounter = 0;
        
        // // KEEP PLANTING GRASS AS LONG AS COUNTER < 200!

        // // but ohhh... WHILE LOOPS ARE DANGEROUS

        // while(grassCounter < grassMax)
        // {
        //     // THIS IS WHERE WE ACTUALLY INSTANTIATE THE GRASS
        //     Vector3 spawnPos = new Vector3 (
        //                                     Random.Range(-3.5f,3.5f),
        //                                     0,
        //                                     Random.Range(-3.5f,3.5f));

        //     Instantiate(gameGrassPrefab, spawnPos, Quaternion.Euler(0, Random.Range(0,359), 0));

        //     grassCounter ++;
        // }


        for (int i = 0; i < grassMax; i++)
        {
            // RANDOMIZE SPAWNPOINT
            Vector3 spawnPos = new Vector3 (Random.Range(-3.5f,3.5f),
                                            0,
                                            Random.Range(-3.5f,3.5f));

            // RANDOMIZE ROTATION
            Vector3 randomRotation = new Vector3 (0,
                                                  Random.Range(0,359),
                                                  0);

            // INSTANTIATE BASED ON LOCATION AND ROTATION
            Instantiate(gameGrassPrefab, spawnPos, Quaternion.Euler(randomRotation));

        }


    }
}
