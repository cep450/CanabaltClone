using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public PlayerRunning player;

    public GameObject prefabEmpty;
    public GameObject prefabNormal;
    public GameObject prefabCracked;
    public GameObject prefabIBeam;
    public GameObject prefabWindow;
    public GameObject prefabCrane;




///////////// the tuning zone ///////////////

    float minGapSize = 1f;
    float maxGapSizeMultiplier = 2f/3f; //


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



    int texturePixelMultiple = 14; //pixels wide each texture is

    int normalBuildingsCounter = 0; //normal buldings in a row since last unusual building



    //temporary timer //////////////////
    int counter = 0;
    int counterMax = 100;
    ////////////////////////////////////


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

        //TEMPORARY timer /////////////////////////
        if(counter > counterMax) {
            counter = 0;
            generateBuilding();
        } else {
            counter++;
        }
        /////////////////////////////////////////
    }

    void generateBuilding() {

        //generate empty space

        float spaceLength = generateSpaceLength();
        BuildingCreator newEmptySpaceScript = Instantiate(buildingEmpty.prefab).GetComponent<BuildingCreator>();
        newEmptySpaceScript.generate(0, spaceLength);
        //move the position of the generator based on the length of the gap
        updatePosition(0, spaceLength);

        
        //generate the building 

        float buildingLength = generateBuildingLength(spaceLength);
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

        GameObject prefabToReturn = buildingNormal.prefab;

        if(normalBuildingsCounter < minNormalInARow) {
            normalBuildingsCounter++;
        } else if(normalBuildingsCounter < maxNormalInARow{
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

    float generateBuildingHeightDiff() {

        //TODO



        return 0;
    }

    float generateBuildingLength(float gapSize) {



//TODO:
        float widthOfScreen; //TODO figure out how to get this in like in-world size
        float minBuildingLength = widthOfScreen - gapSize;
        float maxBuildingLength = minBuildingLength * 2;

        return Random.Range(minBuildingLength, maxBuildingLength);

    }

    float generateSpaceLength() {

        float maxGapSize = maxGapSizeMultiplier * player.getSpeed();

        Debug.Log("max gap size:" + maxGapSize); //////////

        return Random.Range(minGapSize, maxGapSize);

    }

    void generateStartingBuilding() {









    }

}

