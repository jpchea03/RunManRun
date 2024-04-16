using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float jumpSpeed = 10f; //jump force
    public Transform groundCheck; //groundCheck object
    public float groundCheckRadius; //radious of groundCheck circle
    public LayerMask groundLayer; //layer for ground objects
    private bool isGrounded; //determines if player is on ground
    private Rigidbody2D rb; //rigid body for physics

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //set value of isGrounded based on overlap from circle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded) //jump button pressed and player on ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); //make player jumps
        }
    }
}
