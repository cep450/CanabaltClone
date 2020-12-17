using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSprite : MonoBehaviour
{


    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;
    public Sprite spr4;
    public Sprite spr5;


    // Start is called before the first frame update
    void Start()
    {
        Sprite spriteChosen = null;
        while(spriteChosen == null) {
            int rand = Random.Range(1, 5);
            if(rand == 1) {
                spriteChosen = spr1;
            } else if(rand == 2) {
                spriteChosen = spr2;
            } else if(rand == 3) {
                spriteChosen = spr3;
            } else if(rand == 4) {
                spriteChosen = spr4;
            } else if(rand == 5) {
                spriteChosen = spr5;
            }
        }

        GetComponent<SpriteRenderer>().sprite = spriteChosen;
    }

}
