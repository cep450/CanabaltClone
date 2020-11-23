using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour
{

    float length;
    float height;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generate(float heightDiff, float length) {

        //set the length- widen the base prefab
        //set the height position 

        //create a killplane for falling off the bottom of the screen (needed for falling buildings, ibeams, cranes)
        //actually
        //prefab should come with a killplane 
        //which should be widened along with the building itself 
        //yeah ok so the killplane will come with the thing 
        //ACTUALLY
        //killplane needs to be at a specific height compared to uhhh the top of the thing 
        //so we actually need to set the position of the killplane and set the position of the side hitboxes

        //however, we need something to create the side hitboxes so that they don't get widened 
        //maybe a script on them? 
        //or, modify them based on a tag 

        //set y of killplane 
        
        //fix width of side hitboxes

        //tile its sprites (might put this in subclasses that override and call this via super)

    }

}
