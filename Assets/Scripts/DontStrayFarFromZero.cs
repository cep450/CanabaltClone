using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: moves the object back to 0,0 if it gets too far from 0
//USEAGE: put on an empty parent object with all the other game objects as children of it

public class DontStrayFarFromZero : MonoBehaviour
{

    float maxDistanceFromZero = 10000;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > maxDistanceFromZero) {
            //TODO
        }
    }
}
