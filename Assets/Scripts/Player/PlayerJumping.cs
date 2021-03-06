﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    // Put under player object, in control of jumping
    // **Note that in Project Settings, the two inputs for "Jumping" are "Space" and "Left MB"
    Rigidbody2D myRb;
    Animator ani;
    public Sprite preJump;

    public float jumpForceDefault; // default jump force, baseline
    float jumpForce; // actual jump force being used in code

    public bool isGrounded; // grounded check, used by GroundedCheck script
    public bool isJumping; // jumping 

    private float jumpTimeCounter;
    public float jumpTime;

    private float yB4Jump;
    private bool gotY;
    private float yAftJump;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        // initializze jump force
        jumpForce = jumpForceDefault;
    }

    void Update()
    {
        // initialize jump
        if (Input.GetButtonDown("Jump") && isGrounded) {
            GetComponent<SpriteRenderer>().sprite = preJump;
            Jump();
        }
        // mid-air holding for longer jump
        if (Input.GetButton("Jump") && isJumping == true) {
            Jump_Hold();
        }
        // fall
        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
        }

        if (!isGrounded && !gotY) {
            yB4Jump = transform.position.y;
            gotY = true;
        }
        if (isGrounded && gotY) {
            yAftJump = transform.position.y;
            if (yB4Jump - yAftJump > 5f) {
                ani.SetTrigger("RollTrigger");
                Debug.Log("fall roll");
            }
            gotY = false;
        }

        Jump_Animation();

        //Debug.Log();
    }

    // jump code
    void Jump()
    {
        isJumping = true;
        jumpTimeCounter = jumpTime;
        myRb.velocity = Vector2.up * jumpForce;
    }

    // jump holding
    void Jump_Hold()
    {
        if (jumpTimeCounter > 0) {
            myRb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
        }
        else {
            isJumping = false;
        }
    }

    // jump animation
    void Jump_Animation()
    {
        if (!isGrounded) 
        {
            ani.SetBool("isJumping", true);
        }
        else
        {
            ani.SetBool("isJumping", false);
        }
    }
}
