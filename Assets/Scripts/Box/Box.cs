using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    SpriteRenderer sprite;
    int rand;
    public Sprite[] boxTexture;
    bool fall;

    void Start()
    {
        rand = Random.Range(0, boxTexture.Length);
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = boxTexture[rand];
        fall = false;
    }

    void FixedUpdate()
    {
        if (fall) {
            Fall();
        }
    }

    void OnTriggerEnter2D(Collider2D activator) {
        if (activator.tag == "Player") {
            fall = true;
        }
    }

    void Fall() {
        sprite.color = new Color(255f, 255f, 255f, Mathf.PingPong(Time.time*4f, 1f));
        transform.position += new Vector3(0f, -.2f, 0f);
        transform.Rotate (Vector3.back*4f);
    }
}
