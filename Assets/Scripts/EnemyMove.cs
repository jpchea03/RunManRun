using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour

    
{

    public float movingSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move left
        GetComponent<Rigidbody2D>().velocity = new Vector2(-movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
