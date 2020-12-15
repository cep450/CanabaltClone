using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTiler : MonoBehaviour
{

    public Sprite sprCorner;
    public Sprite sprTop;
    public Sprite sprSide;
    public Sprite sprInterior1;
    public Sprite sprInterior2;
    public Sprite sprInterior3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void tile(int numVertical, int numHorizontal) {

        //first row- the roof 
        //first corner 
        ///////TODO
        //middle pieces 
        //int sprTopWidth = sprTop.

        //place left corner
        //TODO

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


    public Sprite pickInterior() {
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
