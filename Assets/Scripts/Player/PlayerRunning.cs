using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    // Put under player object, in control of running
    private Rigidbody2D myRb;
    float runningSpeed; // current running speed of player
    public float runningSpeedDefault; // default running speed
    public float runningSpeedMax; // max speed to run at
    public float runningSpeedDifference = 0.01f; // change in running speed as run goes on
    public float runningSpeedSlowdown = 5f;
    
    float distanceTotal; // total distance traveled by player, also the score
    float xCurrent; // current distance to origin, controlling to snap player back
    public float xMax = 100; // distance threshold, when reached snap player back
    
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        // initialize running speed
        runningSpeed = runningSpeedDefault;
    }

    void FixedUpdate()
    {
        // speed controls
        runningSpeed += runningSpeedDifference;
        // make sure player not running too fast
        if (runningSpeed > runningSpeedMax) {
            runningSpeed = runningSpeedMax;
        }

        // runs
        myRb.velocity = new Vector2(runningSpeed, myRb.velocity.y);

        // position controls

        Debug.Log(distanceTotal);
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

    // slow player down
    public void Slow_Down()
    {
        runningSpeed -= runningSpeedSlowdown;

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
}
