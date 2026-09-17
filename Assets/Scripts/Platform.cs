using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private int platformNumber;

    [SerializeField] private GameObject pelletPrefab;
    [SerializeField] private BoxCollider pelletSpawnArea;

    private bool pelletSpawned = false; // default not spawned until triggered
    private List<FoodPellet> foodPellets = new List<FoodPellet>();
    
    public int PlatformNumber
    {
        get
        { 
            return platformNumber;
        }
    }

    // spawn trigger
    public void PlayerEntered()
    {
        if (!pelletSpawned)
        {
            //Debug.Log("spawning pellets");
            SpawnFoodPellets();
            pelletSpawned = true;
        }
    }

    // random spawn
    public void SpawnFoodPellets()
    {
        //Debug.Log("SpawnFoodPellets() running");
        
        for (int i = 0; i < 8; i++)
        {
            Vector3 spawnPoint = GetRandomFoodPelletPosition();

            GameObject pelletObject = Instantiate(pelletPrefab, spawnPoint, pelletPrefab.transform.rotation);
            FoodPellet pellet = pelletObject.GetComponent<FoodPellet>();
            pellet.Initialize(this);

            foodPellets.Add(pellet); // add to list
        }
        
    }

    // sighhh get random position no overlap in bounds
    private Vector3 GetRandomFoodPelletPosition()
    {
        Bounds bounds = pelletSpawnArea.bounds; // get the bounds of the spawn area
        
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.center.y; // so that it doesnt spawn in the platform

        return new Vector3(x, y, z);
    }


}
