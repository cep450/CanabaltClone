using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: moves the object back to 0,0 if it gets too far from 0
//USEAGE: put on an empty parent object with all the other game objects as children of it
//      !! give it the player object in the inspector !! 
public class DontStrayFarFromZero : MonoBehaviour
{

    float maxDistanceFromZero = 10000;

    //u know what.... im declaring this out of scope 

    //TODO:
    /*
    this should actually check the position of the player object (given in inspector)
    and then, it should move every child of itself back by that max distance amount
    since the parent object itself will stay at 0,0
    */

    //public Transform playerTransform; // !! assign in inspector !!


    // Update is called once per frame
    void Update()
    {
        //if(playerTransform.position.x > maxDistanceFromZero) {
        //    transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        //}
    }
}
