using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MarkovChain : MonoBehaviour
{

    Chain chain;

    int timerLimit = 30;
    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        chain = new Chain("--| [");
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if(timer <= 0) {
            timer = timerLimit;
            chain.iterate();
            Debug.Log(Chain.level);
        }
    }


}

/*
do i want to do structs instead of parallel arrays??
*/


public class Chain {


    //for text demo only
    //the initial characters represent the beginning of the level always being the
    //same stuff generated
    public static string level;

    ChainLink currentLink;


    EmptySpace emptySpace = new EmptySpace();
    BuildingFront buildingFront = new BuildingFront();
    BuildingMid buildingMid = new BuildingMid();
    BuildingEnd buildingEnd = new BuildingEnd();


    public Chain(string lvl) {
        initChain();
        currentLink = buildingFront;
        level = lvl;
    }

    public void initChain() {

        emptySpace.addLinks(emptySpace, buildingFront);
        emptySpace.addChances(0.6, 0.4);

        buildingFront.addLinks(buildingMid);
        buildingFront.addChances(1);

        buildingMid.addLinks(buildingMid, buildingEnd);
        buildingMid.addChances(0.7, 0.3);

        buildingEnd.addLinks(emptySpace);
        buildingEnd.addChances(1);

/*
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
*/
    }

        public void iterate() {
        currentLink = currentLink.getNext();
        currentLink.generate();
    }

/*
    ChainLink [] arr(params ChainLink[] links) {
        return links;
    }
    double [] arr(params double[] doubles) {
        return doubles;
    }
    */
}


public abstract class ChainLink {

    protected ChainLink [] links;
    protected double [] chances;

    
    public ChainLink() {
    }

    public void addLinks(params ChainLink [] chains) {
        links = chains;
    }
    public void addChances(params double [] doubles) {
        chances = doubles;
    }

    /*
    public ChainLink(ChainLink[] li, double[] ch) {
        links = li; 
        chances = ch;
    }
    */

    public abstract void generate();

    public ChainLink getNext() {
        float rand = Random.Range(0,1);
        double tracker = chances[0];
        ChainLink nextLink = links[0];
        for(int i = 1; i < links.Length; i++) {
            tracker += chances[i];
            if(tracker > rand) {
                break;
            }
            nextLink = links[i];
        }
        return nextLink;
    }

}


public class EmptySpace : ChainLink {

    //public EmptySpace(ChainLink [] li, double [] ch) : base(li, ch){}
    public override void generate() {
        Chain.level = Chain.level + " ";
    }
    
}

public class BuildingFront : ChainLink {

    //public BuildingFront(ChainLink [] li, double [] ch) : base(li, ch){}

    public override void generate() {
        Chain.level = Chain.level + "[";
    }
    
}

public class BuildingMid : ChainLink {

    //public BuildingMid(ChainLink [] li, double [] ch) : base(li, ch){}

    public override void generate() {
        Chain.level = Chain.level + "-";
    }
    
}

public class BuildingEnd : ChainLink {

    //public BuildingEnd(ChainLink [] li, double [] ch) : base(li, ch){}

    public override void generate() {
        Chain.level = Chain.level + "]";
    }
    
}
