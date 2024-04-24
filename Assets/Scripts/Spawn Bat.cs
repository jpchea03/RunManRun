using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBat : MonoBehaviour
{
    //variables and objects
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

        GameObject spawnedEnemy;

        if (ranChance <= 5)
        {
            ranChance = Random.Range(1, 5);

            if (ranChance <= 2)
                spawnedEnemy = Instantiate(enemy, transform.position + new Vector3(randomX + 10f, randomY + ranChance, 0), transform.rotation);
            else
            {
                if (randomY > 7.0f)
                    spawnedEnemy = Instantiate(enemy, transform.position + new Vector3(randomX + 10f, randomY - 1f, 0), transform.rotation);
            }

        }


        // Destroy the spawned object after 10 seconds
        Destroy(enemy, 10f);
    }
}
