﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MarkovChain : MonoBehaviour
{

    Chain chain;

    int timerLimit = 20;
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
TODO
- need to make values able to be tuned in real time. ex. more empty space when
player is moving faster. 
- saving data between stuff. ex. pieces of the same building generate at the same height.
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

    CrackedFront crackedFront = new CrackedFront();
    CrackedMid crackedMid = new CrackedMid();
    CrackedEnd crackedEnd = new CrackedEnd();

    WindowFront windowFront = new WindowFront();
    WindowMid windowMid = new WindowMid();
    WindowEnd windowEnd = new WindowEnd();

    Billboard billboard = new Billboard();


    public Chain(string lvl) {
        initChain();
        currentLink = buildingFront;
        level = lvl;
    }

    public void initChain() {

        emptySpace.addLinks(emptySpace, buildingFront, crackedFront, windowFront, billboard);
        emptySpace.addChances(0.6,      0.37,           0.025,        0.025,        0.025);


        buildingFront.addLinks(buildingMid);
        buildingFront.addChances(1);

        buildingMid.addLinks(buildingMid, buildingEnd);
        buildingMid.addChances(0.7, 0.3);

        buildingEnd.addLinks(emptySpace);
        buildingEnd.addChances(1);


        crackedFront.addLinks(crackedMid);
        crackedFront.addChances(1);

        crackedMid.addLinks(crackedMid, crackedEnd);
        crackedMid.addChances(0.7, 0.3);

        crackedEnd.addLinks(emptySpace);
        crackedEnd.addChances(1);


        windowFront.addLinks(windowMid);
        windowFront.addChances(1);

        windowMid.addLinks(windowMid, windowEnd);
        windowMid.addChances(0.7, 0.3);

        windowEnd.addLinks(emptySpace);
        windowEnd.addChances(1);


        billboard.addLinks(emptySpace);
        billboard.addChances(1);

    }

        public void iterate() {
        currentLink = currentLink.getNext();
        currentLink.generate();
    }

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

    public abstract void generate();

    public ChainLink getNext() {
        float rand = Random.Range(0f,sumArr(chances)); //the %s don't have to sum to 1- makes it less of a pain tuning
        double tracker = 0;
        ChainLink nextLink = links[0];
        for(int i = 0; i < links.Length; i++) {
            if(tracker > rand) {
                break;
            }
            nextLink = links[i];
            tracker += chances[i];
        }
        return nextLink;
    }

    float sumArr(double [] darr) {
        float counter = 0;
        for(int i = 0; i < darr.Length; i++) {
            counter += (float)darr[i];
        }
        return counter;
    }

}


public class EmptySpace : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + " ";
    }
    
}

public class BuildingFront : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "[";
    }
    
}

public class BuildingMid : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "-";
    }
    
}

public class BuildingEnd : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "]";
    }
    
}

public class CrackedFront : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "{";
    }
}

public class CrackedMid : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "~";
    }
}

public class CrackedEnd : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "}";
    }
}

public class WindowFront : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "|";
    }
}

public class WindowMid : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "=";
    }
}

public class WindowEnd : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "|";
    }
}

public class Billboard : ChainLink {

    public override void generate() {
        Chain.level = Chain.level + "#";
    }
}