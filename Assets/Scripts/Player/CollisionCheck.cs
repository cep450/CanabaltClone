using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public PlayerRunning playerRunning; // assign to PlayerRunning script
    public Collider2D box; // assign to collider on box (obstacles)

    void OnTriggerEnter2D(Collider2D activator) {
        if (activator == box) {
            playerRunning.boxCollided = true;
        }
    }
}
