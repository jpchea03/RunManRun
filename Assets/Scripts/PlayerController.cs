using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1;
    private bool _isGrounded = true;

    Animator animator;

    bool _isPlaying_run = false;
    bool _isPlaying_slide = false;
    bool _isPlaying_jump = false;

    const int STATE_IDLE = 0;
    const int STATE_RUN = 1;
    const int STATE_JUMP = 2;
    const int STATE_SLIDE = 3;

    string _currentDirection = "left";
    int _currentAnimationState = STATE_IDLE;

    bool sliding = false; //Variable to track if the player is sliding
    float slideTimer = 0f; //Timer for tracking slide duration
    float maxSlideTime = 0.2f; //Maximum duration of the slide


    //Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("up") && !_isPlaying_slide)
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600)); //simple jump code using unity physics
                changeState(STATE_JUMP);
            }

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            if (horizontalInput != 0)
            {
                //Apply horizontal force while jumping
                float jumpHorizontalForce = 5f; 
                GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalInput * jumpHorizontalForce, 0));
            }
        }
        else if (Input.GetKeyDown("down") && !_isPlaying_jump)
        {
            if (_isGrounded && !sliding) 
            {
                sliding = true;
                slideTimer = 0f;
                changeState(STATE_SLIDE);
            }
        }
        else if (Input.GetKey("right") && !_isPlaying_slide)
        {
            changeDirection("right");
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);

            if (_isGrounded)
                changeState(STATE_RUN);

        }
        else if (Input.GetKey("left") && !_isPlaying_slide)
        {
            changeDirection("left");
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);

            if (_isGrounded)
                changeState(STATE_RUN);
        }
        else
        {
            if (_isGrounded)
                changeState(STATE_IDLE);
        }


        //Slide timer
        if (sliding)
        {
            slideTimer += Time.deltaTime;
            if (slideTimer >= maxSlideTime)
            {
                sliding = false;
                changeState(STATE_IDLE); 
            }
        }

        //Horizontal movement while sliding
        if (sliding)
        {
            //Define the slide distance
            float slideDistance = 0.2f; // Adjust as needed

            //Get the current horizontal input
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            //Move the character horizontally while sliding
            transform.Translate(Vector3.right * horizontalInput * slideDistance);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_running"))
        {
            _isPlaying_run = true;
        }
        else
        {
            _isPlaying_run = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Jumping"))
        {
            _isPlaying_jump = true;
        }
        else
        {
            _isPlaying_jump = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_sliding"))
        {
            _isPlaying_slide = true;
        }
        else
        {
            _isPlaying_slide = false;
        }
    }

    void changeState(int state)
    {
        if (_currentAnimationState == state)
            return;

        switch (state)
        {
            case STATE_RUN:
                animator.SetInteger("state", STATE_RUN);
                break;

            case STATE_SLIDE:
                animator.SetInteger("state", STATE_SLIDE);
                break;

            case STATE_JUMP:
                animator.SetInteger("state", STATE_JUMP);
                break;

            case STATE_IDLE:
                animator.SetInteger("state", STATE_IDLE);
                break;
        }

        _currentAnimationState = state;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Floor" || coll.gameObject.CompareTag("obstacle"))
        {
            _isGrounded = true;
            changeState(STATE_IDLE);
        }
    }

    void changeDirection(string direction)
    {
        if (_currentDirection != direction)
        {
            if (direction == "right")
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                _currentDirection = "right";
            }
            else if (direction == "left")
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                _currentDirection = "left";
            }
        }
    }
}
