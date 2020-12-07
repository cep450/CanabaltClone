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
        Vector3 lengthVec3 = new Vector3(length, 1f, 1f);
        transform.localScale += lengthVec3;


        //set the x position. but don't forget to account for the length
        //(ie actual pos is minus half the length)
        float xToTranslate = xpos - (length / 2f);

        //and, the y to move- these are usually set y = -something to make their tops at 0, so 
        //WAIT NVM this is using transform.translate.
        //float yToTranslate = transform.position.y + height;

        //now, set that and set the height- move the building up from the baseline y=0
        transform.Translate(xToTranslate, height, 0f);

        //but, make sure the children aren't scaled horizontally. (undo their scaling)
        float lengthUndo = 1f/length;

        Transform [] childTransforms = GetComponentsInChildren<Transform>();

        //fix the children 
        foreach(Transform t in childTransforms) {

            if(t.gameObject.name.Equals("Killplane")) { //has to be name cause tag is used- deathTrigger
                //move killplanes down to y=0
                t.Translate(0, -height, 0);
            } else if(!t.Equals(transform) && !t.gameObject.tag.Equals("dontSquishMe")) {
                //if it's not a killplane, the original, or something not to change, fix the width
                t.localScale = new Vector3(t.localScale.x * lengthUndo, t.localScale.y, t.localScale.z);
            }
            
        }

        //finally, decorate it with sprites :]
        //tile sprites, and 
        //add a thing on top 

        //TODO
        tileSprites();
        putTopOfBuildingSprite();

    }


    void tileSprites() {

        //TODO

    }

    void putTopOfBuildingSprite() {

        //TODO

    }

}
