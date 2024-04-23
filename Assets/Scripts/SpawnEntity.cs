using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntity : MonoBehaviour
{
    //Variables and objects
    public GameObject obstaclePrefab; //the obstacle prefab that is spawned
    public GameObject enemyPrefab; //The enemy prefab that is spawned on top of obstacles
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenObstacleSpawn; //Time between spawning obstacles
    public float enemyspawnProbability = 0.5f;
    private float spawnTime;

    //Update is called once per frame
    void Update()
    {
        //Checks if enough time has passed between spawns
        if (Time.time > spawnTime)
        {
            SpawnObstacle();
            spawnTime = Time.time + timeBetweenObstacleSpawn;
        }
    }

    void SpawnObstacle()
    {
        //Picks random x and y values from given range
        float randomX = UnityEngine.Random.Range(minX, maxX);
        float randomY = UnityEngine.Random.Range(minY, maxY);

        //Instantiate the obstacle at a random position
        GameObject spawnedObstacle = Instantiate(obstaclePrefab, transform.position + new Vector3(randomX, randomY, 0), Quaternion.identity);

        //Randomly decide whether to spawn an enemy on top of this obstacle
        if (UnityEngine.Random.value < enemyspawnProbability)
        {
            //Adjust the position of the enemy prefab to appear on top of the obstacle along the Y-axis
            Vector3 enemyPosition = spawnedObstacle.transform.position + Vector3.up * spawnedObstacle.GetComponent<SpriteRenderer>().bounds.size.y / 2;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);

            //Destroy the spawned enemy after 10 seconds
            Destroy(spawnedEnemy, 10f);
        }

        //Destroy the spawned obstacle after 10 seconds
        Destroy(spawnedObstacle, 10f);
    }
}
