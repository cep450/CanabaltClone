using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: generate tha buildings 
//USEAGE: put on an empty object **AT X=0, Y=0**
//and make sure to feed it building prefabs and a player :]
public class Generator : MonoBehaviour
{

    public PlayerRunning player;

    public GameObject prefabEmpty;
    public GameObject prefabNormal;
    public GameObject prefabCracked;
    public GameObject prefabIBeam;
    public GameObject prefabWindow;
    public GameObject prefabCrane;


    float cameraPosBuffer = 1f; //determining when to generate the next building 

    float screenWidthInWorld;
    float screenHeightInWorld;
    float screenWidthInWorldHalf;

    float bottomOfScreen = 0; //y=0

    float maxBuildingHeight;
    float minBuildingHeight;


    public static float tileWidthInWorld = 0.7f; //how wide each tile is

///////////// the tuning zone ///////////////

    float heightDiffSpeedMultiplier = 0.11f; //this is multiplied by the running speed to get the
                                          //max positive vertical height difference between buildings

    float heightAllowanceFromTop = 2f;
    float heightAllowanceFromBottom = 2f;

    float minGapSize = 2.3f;
    float maxGapSizeMultiplier = 2f/3f - 0.05f; //

    float minMinBuildingLength = 8f; //TODO- 96 pixels 


    int minNormalInARow = 3; //
    int maxNormalInARow = 8; //
    float probabilitySpecialBuilding = 0.2f;


    float probabilityCracked = 0.25f;
    float probabilityIBeam = 0.25f;
    float probabilityWindow = 0.25f;
    float probabilityCrane = 0.25f;

/////////////////////////////////////////////



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



    int normalBuildingsCounter = 0; //normal buldings in a row since last unusual building
    float lastHeight = 1.5f;



    void Start()
    {

        //get the width and height of the screen in in-world units to use for generation

        screenHeightInWorld = Camera.main.orthographicSize * 2;
        screenWidthInWorld = screenHeightInWorld * Camera.main.aspect;
        screenWidthInWorldHalf = screenWidthInWorld / 2f;

        //

        maxBuildingHeight = screenHeightInWorld - heightAllowanceFromTop;
        minBuildingHeight = bottomOfScreen + heightAllowanceFromBottom;

        //init everything 

        buildingEmpty = new BuildingStruct(1, prefabEmpty);
        buildingNormal = new BuildingStruct(1, prefabNormal);
        buildingCracked = new BuildingStruct(probabilityCracked, prefabCracked);
        buildingIBeam = new BuildingStruct(probabilityIBeam, prefabIBeam);
        buildingWindow = new BuildingStruct(probabilityWindow, prefabWindow);
        buildingCrane = new BuildingStruct(probabilityCrane, prefabCrane);

        specialBuildings = new BuildingStruct [] {buildingCracked, buildingIBeam, buildingWindow, buildingCrane};

        //TODO final vers will generate a special starting building a window building
        //generateStartingBuilding();
    }

    void Update()
    {
        //TODO how to check when a new building needs to be generated?

        //when the right side of the camera approaches the location of the generator, 
        //generate a new building. 
        if(Camera.main.transform.position.x + screenWidthInWorldHalf > transform.position.x - cameraPosBuffer) {
            generateBuilding();
        }

    }

    void generateBuilding() {

        //generate empty space

        float spaceLength = generateSpaceLength();

        //move the position of the generator based on the length of the gap
        updatePosition(spaceLength + 1.5f); //TODO WHY DO I HAVE TO ADD THIS HERE AND THE OTHER UPDATEPOSITION?????????

        BuildingCreator newEmptySpaceScript = Instantiate(buildingEmpty.prefab).GetComponent<BuildingCreator>();
        newEmptySpaceScript.generate(0, spaceLength, transform.position.x);
        

        //generate the building 

        float buildingLength = generateBuildingLength(spaceLength);
        float buildingHeight = generateBuildingHeight();
        GameObject buildingPrefab = pickBuildingPrefab();

        //move the position of the generator based on the length of the new building,
        //and update the stored height value
        updatePosition(buildingHeight, buildingLength + 1.5f);

        BuildingCreator newBuildingScript = Instantiate(buildingPrefab).GetComponent<BuildingCreator>();
        newBuildingScript.generate(buildingHeight, buildingLength, transform.position.x);

    }

    void updatePosition(float length) {
        transform.Translate(new Vector3(length, 0f, 0f));
    }

    void updatePosition(float height, float length) {
        lastHeight = height;
        transform.Translate(new Vector3(length, 0f, 0f));
        
    }

    GameObject pickBuildingPrefab() {

        GameObject prefabToReturn = buildingNormal.prefab;

        if(normalBuildingsCounter < minNormalInARow) {
            normalBuildingsCounter++;
        } else if(normalBuildingsCounter < maxNormalInARow) {
            float rand = Random.Range(0f, 1f);
            if(rand <= probabilitySpecialBuilding * (normalBuildingsCounter - minNormalInARow)) {
                normalBuildingsCounter = 0;
            prefabToReturn = pickSpecialBuilding();
            } else {
                normalBuildingsCounter++;
            }
        } else {
            normalBuildingsCounter = 0;
            prefabToReturn = pickSpecialBuilding();
        }

        return prefabToReturn;
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

    float generateBuildingHeight() {

        //falling buildings. ummm 
        //maybe they set the thing lower when they generate or something 

        float jumpHeightAllowance = player.getSpeed() * heightDiffSpeedMultiplier;
        float maxHeight = Mathf.Min(lastHeight + jumpHeightAllowance, maxBuildingHeight);

        return Random.Range(minBuildingHeight, maxHeight);

    }

    float generateBuildingLength(float gapSize) {

        float minBuildingLength = Mathf.Max(screenWidthInWorld - gapSize, minMinBuildingLength);
        float maxBuildingLength = minBuildingLength * 2;

        float randomLength =  Random.Range(minBuildingLength, maxBuildingLength);
        //BUT, make sure this is a multiple of the size of the sprites. 
        float niceLength = (int)(randomLength / tileWidthInWorld) * tileWidthInWorld;

        return niceLength;

    }

    float generateSpaceLength() {

        float maxGapSize = maxGapSizeMultiplier * player.getSpeed();

        return Random.Range(minGapSize, maxGapSize);

    }

    void generateStartingBuilding() {




        //TODO




    }

}