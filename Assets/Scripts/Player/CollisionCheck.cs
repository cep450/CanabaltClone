using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public PlayerRunning playerRunning; // assign to PlayerRunning script
    
    void OnTriggerEnter2D(Collider2D activator) {
        if (activator.tag == "Box") {
            playerRunning.Slow_Down();
        }

        if (activator.tag == "deathTrigger") {
            playerRunning.Die();
        }

        //activate falling buildings
        if (activator.tag == "FallTrigger") {
            Debug.Log("BUILDING KNOCKED OVER");
            activator.GetComponent<MovingBuilding>().moving = true;
        }

    }
}
