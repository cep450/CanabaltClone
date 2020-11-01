using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MarkovChain : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}


/*
object/class? struct? enum?
*/

    //Link emptySpace, buildingFront, buildingMid, building


public class Chain {

    EmptySpace emptySpace;
    BuildingFront buildingFront;
    BuildingMid buildingMid;
    BuildingEnd buildingEnd;

    public void initChain() {

        emptySpace = new EmptySpace(
            arr(emptySpace, buildingFront),
            arr(0.7, 0.3)
        );

        buildingFront = new BuildingFront(
            arr(buildingMid),
            arr(1)
        );

        buildingMid = new BuildingMid(
            arr(buildingMid, buildingEnd),
            arr(0.7, 0.3)
        );

        buildingEnd = new BuildingEnd(
            arr(emptySpace),
            arr(1)
        );
    }


    ChainLink [] arr(params ChainLink[] links) {
        return links;
    }
    float [] arr(params float[] floats) {
        return floats;
    }
}

public class ChainLink {

    ChainLink [] links;
    float [] chances;

    public ChainLink(ChainLink [] li, float [] ch) {
        links = li;
        chances = ch;
    }
    public void generate();

    public void next() {
        float rand;
    }

}


public class EmptySpace : ChainLink {

    public void generate() {
        print(" ");
    }
    
}

public class BuildingFront : ChainLink {

    public void generate() {
        print("[");
    }
    
}

public class BuildingMid : ChainLink {

    public void generate() {
        print("-");
    }
    
}

public class BuildingBack : ChainLink {

    public void generate() {
        print("]");
    }
    
}
