using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Put under player object, in control of jumping
    // **Note that in Project Settings, the two inputs for "Jumping" are "Space" and "Left MB"
    Rigidbody2D myRb;
    public float jumpForceDefault = 10f; // default jump force, baseline
    float jumpForce; // actual jump force being used in code
    public float jumpForceMax = 15f; // jump force limit
    public float jumpForceDifference = 0.1f; // change in jump force when key held
    public bool isGrounded; // grounded check
    public bool isJumping; // jumping check
    void Start()
    {
        // initializze jump force
        jumpForce = jumpForceDefault;

        myRb = GetComponent<Rigidbody2D>();
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

    // grounded check (with the second box collider, which is a trigger)
    void OnTriggerStay2D(Collider2D activator) {
        isGrounded = true;
    }
    void OnTriggerExit2D(Collider2D activator) {
        isGrounded = false;
    }
}
