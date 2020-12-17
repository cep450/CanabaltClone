using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTiler : MonoBehaviour
{

    public SpriteRenderer sprCorner;
    public SpriteRenderer sprTop;
    public SpriteRenderer sprSide;
    public SpriteRenderer sprInterior1;
    public SpriteRenderer sprInterior2;
    public SpriteRenderer sprInterior3;


    Vector3 sprScale = new Vector3(5f, 5f, 1f);
    Vector3 sprScaleFlipped = new Vector3(-5f, 5f, 1f);


    public bool invertTile; //for top of window buildings.... worry about this later 

    float widthMultiplier = Generator.tileWidthInWorld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //TODO also, need to allow different building types (eventually) 

    public void tile(float width, int numVertical) {


        SpriteRenderer spr;

        int numHorizontal = (int)(width / widthMultiplier);

        float x = transform.position.x - (width / 2);
        float y = transform.position.y;

        //first row- the roof 
        //first corner 
        ///////TODO
        //middle pieces 
        //int sprTopWidth = sprTop.

        //place left corner
        spr = Instantiate(sprCorner);
        spr.transform.Translate(new Vector3(x, y, 0));
        spr.transform.localScale = sprScale;

        //place middle pieces
        for(int i = 1; i < numHorizontal - 1; i++) {

            //place middle pieces
            //TODO

        }

        //place right corner
        //TODO

        //subsequent rows (won't happen if there's only 1 row, like for the I-beam and crane)
        for(int i = 1; i < numVertical - 1; i++) {

            //place left side
            //TODO

            for(int j = 1; j < numHorizontal - 1; j++) {

                //place middle pieces 
                //TODO

            }

            //place right side
            //TODO

        }

    }


    public SpriteRenderer pickInterior() {
        int rand = Random.Range(1, 3);
        if(rand == 1) {
            return sprInterior1;
        } else if(rand == 2) {
            return sprInterior2;
        } else {
            return sprInterior3;
        }
    }

}
