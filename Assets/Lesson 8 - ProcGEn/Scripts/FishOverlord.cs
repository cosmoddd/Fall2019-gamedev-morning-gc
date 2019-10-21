using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// USAGE: put this on an empty GameObject called "FishOverlord"
// INTENT: spawn and control the fish
public class FishOverlord : MonoBehaviour
{

    // REFERENCE TO OUR FISH PREFAB
    public GameObject fishPrefab;

    public int maxFish;

    // A LIST OF ALL THE FISH CLONSE WE HAVE SPAWNED
    public List<GameObject> myFishList = new List<GameObject>();

    void Start()
    {
        for (int fishCounter = 0; fishCounter < maxFish; fishCounter++)
        {
            // THIS IS WHERE WE ACTUALLY SPAWN THE FISH

            // GET A RANDOM SPAWN POSITION
            Vector3 spawnPos = new Vector3(
                                            Random.Range(-5f, 5f),
                                            0f,
                                            Random.Range(-5f,5f));

            // SPAWN THE FISH PREFAB IN A RANDOM PLACE
            GameObject myNewFish = Instantiate (fishPrefab,
                                                spawnPos, 
                                                Quaternion.Euler(0,Random.Range(0,360), 0));

            // ADD FISH TO THE LIST
            myFishList.Add(myNewFish); // 
        }
    }
    
    void Update()
    {
        // PRESS X TO MAKE ALL THE FISH TO TO (0,0,0)
        if (Input.GetKeyDown(KeyCode.X))
        {
            // USE THE TRUSTY FOR LOOP TO TELL ALL FISH IN THE LIST TO RETURN to 0,0,0.
            for (int i=0; i < myFishList.Count; i++)
            {   
                    // HOOK INTO THE FISH SCRIPT (BADUM CHING) WITH GET COMPONENT
                    myFishList[i].GetComponent<Fish>().destination = new Vector3(0,0,0);

            }
        }
        if (Input.GetKeyDown(KeyCode.K))

            // USE THE SLICK FOREACH LOOP TO TELL ALL FISH IN THE LIST TO enlarge.
            foreach (GameObject eachFish in myFishList)
            {   
                   eachFish.transform.localScale *= Random.Range(0.5f, 2f);
            }

        // misc list operations you might find useful
		
		// remove items from the list?
		// myFishList.RemoveAt(5); // "remove item #5 from the list"
		
		// reset the list?
		// myFishList.Clear(); // Clear() will blank-out the list, set size=0
    }

}
