using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: destroy objects that leave the left side of the screen/camera view
//USEAGE: attach to any parent object you want to be destroyed once it leaves the 
//left side of the screen. i.e. will be a component put on building pieces parent
// !! give it a reference to the Camera in the inspector !!

public class CleanupOffscreen : MonoBehaviour
{

    //TODO tune this so it destroys as intended
    //ex. a screen might display a whole lot of objects...?
    float distanceLeftOfCameraCenter = 20;

    //should be set in the inspector
    //TODO is there a way around having to set it? tho, should be fine on prefabs
    public Transform cameraTransform;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < cameraTransform.position.x - distanceLeftOfCameraCenter) {
            Destroy(gameObject);
        }
    }
}
