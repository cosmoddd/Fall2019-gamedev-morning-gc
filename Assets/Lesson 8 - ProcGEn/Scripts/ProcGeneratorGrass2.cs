using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGeneratorGrass2 : MonoBehaviour
{

    public GameObject gameGrassPrefab;

    public int grassMax = 20;



    void Start()
    {
        for (int i = 0; i < grassMax ; i++)
        {
            //RANDOMIZE THE SPAWNPOINT OF THE GRASS
            Vector3 spawnPos = new Vector3 (Random.Range(-4f, 4f),
                                            0,
                                            Random.Range(-4f, 4f));

            // INSTANTIATE BASED ON LOCATION

            GameObject newGrass = Instantiate(gameGrassPrefab, spawnPos, Quaternion.identity);

            newGrass.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color (.554f, 
                                                                                            Random.Range(.3f, .8f),
                                                                                            .9622f));
            
        }        
    }

}
