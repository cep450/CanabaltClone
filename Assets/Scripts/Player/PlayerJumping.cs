using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    // Put under player object, in control of jumping
    // **Note that in Project Settings, the two inputs for "Jumping" are "Space" and "Left MB"
    Rigidbody2D myRb;

    public float jumpForceDefault; // default jump force, baseline
    float jumpForce; // actual jump force being used in code
    public float jumpForceMax; // jump force limit

    public bool isGrounded; // grounded check, used by GroundedCheck script
    public bool isJumping; // jumping 

    private float jumpTimeCounter;
    public float jumpTime;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        // initializze jump force
        jumpForce = jumpForceDefault;
    }

    void Update()
    {
        // initialize jump
        if (Input.GetButtonDown("Jump") && isGrounded) {
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

        Debug.Log(jumpTimeCounter);
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

    //todo
    // play jump_up animation
    // play fall aniation when falling

    // void roll
}
