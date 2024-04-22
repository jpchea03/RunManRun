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

    const int STATE_IDLE = 0;
    const int STATE_RUN = 1;
    const int STATE_JUMP = 2;
    const int STATE_SLIDE = 3;

    string _currentDirection = "left";
    int _currentAnimationState = STATE_IDLE;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("up") && !_isPlaying_slide)
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250)); //simple jump code using unity physics
                changeState(STATE_JUMP);
            }
        }
        else if (Input.GetKey("down"))
        {
            changeState(STATE_SLIDE);
        }
        else if (Input.GetKey("right"))
        {
            changeDirection("right");
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);

            if (_isGrounded)
                changeState(STATE_RUN);

        }
        else if (Input.GetKey("left"))
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
        if (coll.gameObject.name == "Floor")
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
                transform.Rotate(0, 180, 0);
                _currentDirection = "right";
            }
            else if (direction == "left")
            {
                transform.Rotate(0, -180, 0);
                _currentDirection = "left";
            }
        }
    }
}
