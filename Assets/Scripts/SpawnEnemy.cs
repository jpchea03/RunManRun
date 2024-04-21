//Spawns enemies. Very similar to SpawnObstacles.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    //variables and objects
    public GameObject enemy; //the obstacle that is spawned
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        //checks if enough time has passed between spawns
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    //Spawns enemy
    void Spawn()
    {
        //Picks random x and y values from given range
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        GameObject spawnedObstacle = Instantiate(enemy, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

        // Destroy the spawned object after 10 seconds
        Destroy(spawnedObstacle, 10f);
    }
}
