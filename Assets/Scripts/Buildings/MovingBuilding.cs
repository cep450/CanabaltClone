using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: move the building when the player enters a trigger (for cracked building and I-beam)
//USEAGE: put on building prefab parent to move, 
//SPECIFY IN INSPECTOR: movement speed, possibly trigger to check 

public class MovingBuilding : MonoBehaviour
{

    public bool movementSpeedPositive;
    float movementSpeed = 0.045f;
    Vector3 movementVector;

    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        if(movementSpeedPositive) {
            movementVector = new Vector3(0f, movementSpeed, 0f);
        } else {
            movementVector = new Vector3(0f, -movementSpeed, 0f);
        }

    }

    void FixedUpdate() {
        if(moving) {
            transform.Translate(movementVector);
            //TODO: the y=0 killplane shouldnt move along with it

        } else {
            //if it's an i-beam. it's already moving 
            if(movementSpeedPositive) {
                moving = true;
            }

        }
    }


    //activate falling buildings
    void OnTriggerEnter2D(Collider2D activator) {
        if (activator.tag == "Player") {
            Debug.Log("BUILDING KNOCKED OVER");
            moving = true;
        }
    }
       
}
