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
    public float jumpForceDifference = 0.1f; // change in jump force when key held
    public bool isGrounded; // grounded check, used by GroundedCheck script
    public bool isJumping; // jumping check

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        // initializze jump force
        jumpForce = jumpForceDefault;
    }

    void Update()
    {
        // build up jump force while jumping key is held
        if (Input.GetButton("Jump") && isGrounded) {
            // adding jump force with a slight difference each frame jump is held
            jumpForce += jumpForceDifference;
            // there is a thresold for jump force, will revert back to the max jump force is exceeding threshold
            if (jumpForce >= jumpForceMax) {
                jumpForce = jumpForceMax;
            }
        }
        // run jumping code at the frame that jump key is released
        if (Input.GetButtonUp("Jump") && isGrounded) {
            isJumping = true;
        }
    }

    void FixedUpdate() {
        // run jumping code
        if (isJumping) {
            Jump();
        }
    }

    // jumping code
    void Jump()
    {
        myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
        isJumping = false;
        // revert back to default jump force after each jump
        jumpForce = jumpForceDefault;
    }
}
