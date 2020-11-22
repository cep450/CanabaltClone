using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public Rigidbody2D player;

    public GameObject prefabEmpty;
    public GameObject prefabNormal;
    public GameObject prefabCracked;
    public GameObject prefabIBeam;
    public GameObject prefabWindow;
    public GameObject prefabCrane;


    float probabilityCracked = 0.25f;
    float probabilityIBeam = 0.25f;
    float probabilityWindow = 0.25f;
    float probabilityCrane = 0.25f;


    struct BuildingStruct {
        public float probability;
        public GameObject prefab;

        public BuildingStruct(float p, GameObject pf) {
            probability = p;
            prefab = pf;
        }
    }
    
    BuildingStruct buildingEmpty;
    BuildingStruct buildingNormal;
    BuildingStruct buildingCracked;
    BuildingStruct buildingIBeam;
    BuildingStruct buildingWindow;
    BuildingStruct buildingCrane;

    BuildingStruct [] specialBuildings;



    int texturePixelMultiple = 14; //pixels wide each texture is

    int normalBuildingsCounter = 0; //normal buldings in a row since last unusual building

    // Start is called before the first frame update
    void Start()
    {

        //init everything 

        buildingEmpty = new BuildingStruct(1, prefabEmpty);
        buildingNormal = new BuildingStruct(1, prefabNormal);
        buildingCracked = new BuildingStruct(probabilityCracked, prefabCracked);
        buildingIBeam = new BuildingStruct(probabilityIBeam, prefabIBeam);
        buildingWindow = new BuildingStruct(probabilityWindow, prefabWindow);
        buildingCrane = new BuildingStruct(probabilityCrane, prefabCrane);

        specialBuildings = new BuildingStruct [] {buildingCracked, buildingIBeam, buildingWindow, buildingCrane};

        generateStartingBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO how to check when a new building needs to be generated?
    }

    void generateBuilding() {

        //generate empty space

        float spaceLength = generateSpaceLength();
        BuildingCreator newEmptySpaceScript = Instantiate(buildingEmpty.prefab).GetComponent<BuildingCreator>();
        newEmptySpaceScript.generate(0, spaceLength);
        //move the position of the generator based on the length of the gap
        updatePosition(0, spaceLength);

        
        //generate the building 

        float buildingLength = generateBuildingLength();
        float buildingHeightDiff = generateBuildingHeightDiff();
        GameObject buildingPrefab = pickBuildingPrefab();

        BuildingCreator newBuildingScript = Instantiate(buildingPrefab).GetComponent<BuildingCreator>();
        newBuildingScript.generate(buildingHeightDiff, buildingLength);

        //move the position of the generator based on the length of the new building
        updatePosition(buildingHeightDiff, buildingLength);

    }

    void updatePosition(float heightDiff, float length) {
        transform.Translate(new Vector3(length, heightDiff, 0));
    }

    GameObject pickBuildingPrefab() {

        //TODO
        //pick what building type to generate based on the normal building counter 
        return buildingNormal.prefab;
    }

    GameObject pickSpecialBuilding() {

        float rand = Random.Range(0f,1f);
        float tracker = 0;
        GameObject buildingToReturn;
        int i = 0;
        do {
            tracker += specialBuildings[i].probability;
            buildingToReturn = specialBuildings[i].prefab;
            i++;
        } while(tracker <= rand && i < specialBuildings.Length);

        return buildingToReturn;
    }

    float generateBuildingHeightDiff() {

        //TODO
        return 0;
    }

    float generateBuildingLength() {

        //TODO
        return 0;
    }

    float generateSpaceLength() {

        //TODO
        return 0;
    }

    void generateStartingBuilding() {

    }

}


/*
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




*/
