using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public Rigidbody2D player;

    public Transform prefabEmpty;
    public Transform prefabNormal;
    public Transform prefabCracked;
    public Transform prefabIBeam;
    public Transform prefabWindow;
    public Transform prefabCrane;


    float probabilityCracked = 0.25f;
    float probabilityIBeam = 0.25f;
    float probabilityWindow = 0.25f;
    float probabilityCrane = 0.25f;

    BuildingSpecial [] specialBuildings;







    struct BuildingStruct {
        float probability;
        Transform prefab;
        bool isSpecial;

        public BuildingStruct(float p, Transform pf, bool issp) {
            probability = p;
            prefab = pf;
            isSpecial = issp;
        }
    }

    //this would happen in start 
    //BuildingStruct buildingNormal = new BuildingStruct(1, prefabNormal, false);
    //BuildingStruct buildingCracked = new BuildingStruct(0.25, prefabCracked, true);



    int texturePixelMultiple = 14; //pixels wide each texture is

    int normalBuildingsCounter = 0; //normal buldings in a row since last unusual building

    // Start is called before the first frame update
    void Start()
    {
        
        //init special buildings
        BuildingCracked buildingCracked = new BuildingCracked();
        BuildingWindow buildingWindow = new BuildingWindow();
        BuildingIBeam buildingIBeam = new BuildingIBeam();
        BuildingCrane buildingCrane = new BuildingCrane();
        
        specialBuildings = new BuildingSpecial [] {buildingCracked, buildingWindow, buildingIBeam, buildingCrane};

        generateStartingBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO how to check when a new building needs to be generated?
    }

    void generateBuilding() {

        //generate empty space

        //pick what building type to generate based on the normal building counter 
        

    }


    generateEmptySpace() {

    }

    generateNormalBuilding() {

    }

    generateSpecialBuilding() {

    }

    generateStartingBuilding() {

    }



}


public abstract class Building {

    Transform prefab;

    public void setPrefab(Transform p) {
        prefab = p;
    }

    public abstract void generate();
}

public abstract class BuildingSpecial : Building {

    float probability;

    public void setProbability(float p) {
        probability = p;
    }


}


public class BuildingCracked : BuildingSpecial {

    public override void generate() {
        //generate the building
    }

}

public class BuildingIBeam : BuildingSpecial {

    public override void generate() {
        //generate the building
    }

}
public class BuildingWindow : BuildingSpecial {

    public override void generate() {
        //generate the building
    }

}

public class BuildingCrane : BuildingSpecial {

    public override void generate() {
        //generate the building
    }

}





