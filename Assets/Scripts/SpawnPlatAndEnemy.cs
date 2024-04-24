using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatAndEnemy : MonoBehaviour
{
    //variables and objects
    public GameObject obstacle; //the obstacle that is spawned
    public GameObject enemy; //the enemy that is spawned
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

    void Spawn()
    {
        //Picks random x and y values from given range
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        float ranChance = Random.Range(1, 10);

        GameObject spawnedObstacle = Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        GameObject spawnedEnemy;

        if (ranChance <= 5)
        {
            ranChance = Random.Range(1, 5);

            if (ranChance <= 2)
                spawnedEnemy = Instantiate(enemy, transform.position + new Vector3(randomX + 10f, randomY + ranChance, 0), transform.rotation);
            else
            {
                if (randomY>7.0f)
                    spawnedEnemy = Instantiate(enemy, transform.position + new Vector3(randomX + 10f, randomY - 1f, 0), transform.rotation);
            }
                
        }


        // Destroy the spawned object after 10 seconds
        Destroy(spawnedObstacle, 10f);
        Destroy(spawnedObstacle, 15f);
    }
}
