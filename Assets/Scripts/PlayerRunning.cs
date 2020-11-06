using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    private Rigidbody2D myRb;
    public float defaultRunningSpeed;
    
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        myRb.velocity = new Vector2(defaultRunningSpeed, myRb.velocity.y);
    }
}
