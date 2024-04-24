using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1f;
    public float normalJumpForce = 600f;
    public float doubleJumpForce = 600f;

    private bool _isGrounded = true;

    Animator animator;

    bool _isPlaying_run = false;
    bool _isPlaying_slide = false;
    bool _isPlaying_jump = false;

    const int STATE_RUN = 0;
    const int STATE_JUMP = 1;
    const int STATE_SLIDE = 2;

    int _currentAnimationState = STATE_RUN;

    bool sliding = false; //Variable to track if the player is sliding
    float slideTimer = 0f; //Timer for tracking slide duration
    float maxSlideTime = 0.6f; //Maximum duration of the slide

    bool canDoubleJump = false; //Flag to track if the player can double jump
    float doubleJumpCooldown = 0.2f; //Cooldown duration for double jump
    float lastJumpTime = 0f; //Time of the last jump

    bool isjump = false;

    public AudioClip jump;
    public AudioClip run;

    public AudioSource audioSource;

    //Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
    }
<<<<<<< HEAD
=======

>>>>>>> parent of 1aeac71 (Revert "Getting everything together")
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            isjump = true;
        }
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if (isjump && !_isPlaying_slide)
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, normalJumpForce)); //simple jump code using unity physics
                changeState(STATE_JUMP);
                lastJumpTime = Time.time; //Update last jump time
                
                canDoubleJump = true; 
                isjump = false;
            }
            else if (canDoubleJump && Time.time - lastJumpTime > doubleJumpCooldown) //Check for double jump condition
            {
                _isGrounded = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0); //reset vertical velocity
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, doubleJumpForce)); //Apply double jump force
                changeState(STATE_JUMP);
                lastJumpTime = Time.time; //Update last jump time

                canDoubleJump = false;
                isjump = false;
            }
        }
        else if (Input.GetKey("down") && !_isPlaying_jump)
        {
            if (_isGrounded && !sliding) 
            {
                sliding = true;
                slideTimer = 0f;
                changeState(STATE_SLIDE);
            }
        }

        //Slide timer
        if (sliding)
        {
            slideTimer += Time.deltaTime;
            if (slideTimer >= maxSlideTime)
            {
                sliding = false;
                changeState(STATE_RUN); 
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_running"))
        {
            _isPlaying_run = true;
            playRunAudio();
        }
        else
        {
            _isPlaying_run = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Jumping"))
        {
            _isPlaying_jump = true;
            playJumpAudio();
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
        }

        _currentAnimationState = state;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Ground") )
        {
            _isGrounded = true;
            isjump = false;
            canDoubleJump = false;
            changeState(STATE_RUN);
        }
    }

    public void playJumpAudio()
    {
        audioSource.clip = jump;
        audioSource.Play();
    }

    public void playRunAudio()
    {
        audioSource.clip = run;
        audioSource.Play();
    }

}
