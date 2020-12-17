using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAboveZero : MonoBehaviour
{

    float cameraHalfHeight;

    void Start() {
        cameraHalfHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {

        float bottomZeroDifference = Camera.main.transform.position.y - cameraHalfHeight;

        //if the bottom of the camera dips below y=0, don't let it
        if(bottomZeroDifference < 0) {
            Camera.main.transform.Translate(new Vector3(0f, -bottomZeroDifference, 0f));

        }
    }
}
