using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: move the building when the player enters a trigger (for cracked building and I-beam)
//USEAGE: put on building prefab parent to move, 
//SPECIFY IN INSPECTOR: movement speed, possibly trigger to check 

public class MovingBuilding : MonoBehaviour
{

    public float movementSpeed;
    Vector3 movementVector;

    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        movementVector = new Vector3(0f, movementSpeed, 0f);
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving) {
            transform.Translate(movementVector);
            //TODO make this happen RELATIVE TO TIME rather than relative to framerate. 
        } else {
            //TODO check if player enters the right trigger, if so, make it move
            //migbht need a public variable triggerToCheck
        }
    }
}
