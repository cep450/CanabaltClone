using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
   private float length, startPos;
   public GameObject cam;
   public float parralaxEffect;

    public bool clampAtYZero;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp =(cam.transform.position.x * (1 - parralaxEffect));
        float dist = (cam.transform.position.x * parralaxEffect);

        //don't go below 0 to fix flashing in procscene
        float ypos = cam.transform.position.y-0.7f;
        if(clampAtYZero) {
            ypos = Mathf.Max(ypos, Camera.main.orthographicSize - 0.7f);
        }

        transform.position = new Vector3(startPos + dist, ypos, 60f);

        if(temp > startPos + length) startPos += length;
        else if(temp < startPos - length) startPos -= length;
    }
}
