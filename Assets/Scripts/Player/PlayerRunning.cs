using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    // Put under player object, in control of running
    private Rigidbody2D myRb;
    Animator ani; // animator

    public PlayerJumping playerJumping; // assign to PlayerJumping script

    private float runningSpeed; // current running speed of player
    public float runningSpeedMax; // max speed to run at
    private float runningSpeedDifference = 1f; // change in running speed as run goes on
    public float runningSpeedSlowDown = 0.3f;
    
    public float distanceTotal; // total distance traveled by player, also the score
    float xCurrent; // current distance to origin, controlling to snap player back
    public float xMax = 100; // distance threshold, when reached snap player back

    public bool death = false; // death boolean
    
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        // initialize running speed
        runningSpeed = 0f;
    }

    void FixedUpdate()
    {
        ani.SetBool("isRolling", false);
        Speed_Up();
        // runs
        myRb.velocity = new Vector2(runningSpeed, myRb.velocity.y);

        // position controls

        //Debug.Log();
    }

    // speed player up
    void Speed_Up()
    {
        // speed controls
        runningSpeed += runningSpeedDifference;
        if (runningSpeed < 1)
        {
            runningSpeedDifference = 0.5f;
            playerJumping.jumpTime = 0.03f;
        }
        else if (runningSpeed < 5)
        {
            runningSpeedDifference = 0.3f;
            playerJumping.jumpTime = 0.08f;
        }
        else if (runningSpeed < 15)
        {
            runningSpeedDifference = 0.1f;
            playerJumping.jumpTime = 0.13f;
        }
        else if (runningSpeed < 30)
        {
            runningSpeedDifference = 0.01f;
            playerJumping.jumpTime = 0.25f;
        }

        // max out
        if (runningSpeed > runningSpeedMax)
        {
            runningSpeed = runningSpeedMax;
        }
    }

    // slow player down when hitting obstacles
    public void Slow_Down()
    {
        if (playerJumping.isGrounded == true) {
            runningSpeed = runningSpeed * runningSpeedSlowDown;
            ani.SetBool("isRolling", true);
        }
    }

    // player death
    public void Die()
    {
        runningSpeedMax = 0;
        death = true;
    }

    // getter functions to find out speed & location
    public float getCurrentDistanceFromOrigin() {
        return xCurrent;
    }
    public float getDistanceTraveled() {
        return distanceTotal;
    }
    public float getSpeed() {
        return runningSpeed;
    }
}
