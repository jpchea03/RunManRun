using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
           
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EndGameCheck egc = GetComponent<EndGameCheck>();
        // Check if the collided object is an enemy prefab
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Handle the collision (e.g., reduce player health, play an effect)
            //Debug.Log("Player collided with an enemy!");
            // Add your custom logic here

            egc.EndGame();
        }
    }
}
