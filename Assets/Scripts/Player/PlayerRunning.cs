﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    // Put under player object, in control of running
    private Rigidbody2D myRb;

    public PlayerJumping playerJumping; // assign to PlayerJumping script

    private float runningSpeed; // current running speed of player
    public float runningSpeedMax; // max speed to run at
    private float runningSpeedDifference = 1f; // change in running speed as run goes on
    public float runningSpeedSlowDown = 0.3f;
    
    float distanceTotal; // total distance traveled by player, also the score
    float xCurrent; // current distance to origin, controlling to snap player back
    public float xMax = 100; // distance threshold, when reached snap player back
    
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        // initialize running speed
        runningSpeed = 0f;
    }

    void FixedUpdate()
    {
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
            playerJumping.jumpTime = 0.05f;
        }
        else if (runningSpeed < 5)
        {
            runningSpeedDifference = 0.3f;
            playerJumping.jumpTime = 0.1f;
        }
        else if (runningSpeed < 15)
        {
            runningSpeedDifference = 0.1f;
            playerJumping.jumpTime = 0.25f;
        }
        else if (runningSpeed < 30)
        {
            runningSpeedDifference = 0.01f;
            playerJumping.jumpTime = 0.5f;
        }

        // max out
        if (runningSpeed > runningSpeedMax)
        {
            runningSpeed = runningSpeedMax;
        }
    }

    // slow player down
    public void Slow_Down()
    {
        runningSpeed = runningSpeed * runningSpeedSlowDown;

        //todo
        // roll
    }

    // player death
    public void Die()
    {
        runningSpeedMax = 0;

        //todo
        // trigger death state
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
