using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour
{

    float length;
    float height;


    /////TODO will also have sprite tiles 
    //public sprite spriteCorner;
    //public sprite spriteTop;
    //public sprite spriteSide;
    //public Sprite spriteMiddle;

    public void generate(float height, float length, float xpos) {

        //set the length- widen the base prefab 
        Vector3 lengthVec3 = new Vector3(length * 1f, 1f, 1f);
        transform.localScale += lengthVec3;

        Debug.Log("length " + length + ", transform.localscale.x=" + transform.localScale.x);

        //but, make sure the children aren't scaled horizontally. (undo their scaling)
        float lengthUndo = 1f/length;
        Transform [] childTransforms = GetComponentsInChildren<Transform>();
        foreach(Transform t in childTransforms) {
            t.localScale = new Vector3(t.localScale.x * lengthUndo, t.localScale.y, t.localScale.z);
        }


        //set the x position. but don't forget to account for the length
        //(ie actual pos is minus half the length)
        float xToTranslate = xpos - (length / 2f);

        //now, set that and set the height- move the building up from the baseline y=0
        transform.Translate(xToTranslate, height, 0f);

        //but, if there's a killplane, move it back down to 0 
        foreach(Transform t in childTransforms) {
            if(t.gameObject.name.Equals("Killplane")) { //has to be name cause tag is used- deathTrigger
                t.Translate(0, -height, 0);
            }
        }


        //finally, decorate it with sprites :]
        //tile sprites, and 
        //add a thing on top 

        //TODO

    }

}
