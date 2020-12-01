using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
   private float length, startPos;
   public GameObject cam;
   public float parralaxEffect;
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

        transform.position = new Vector3(startPos + dist, cam.transform.position.y-0.7f, 60f);

        if(temp > startPos + length) startPos += length;
        else if(temp < startPos - length) startPos -= length;
    }
}
