using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform player; // player transform
    private Vector3 playerPosition; // current player position
    private Vector3 target; // camera target position
    private Vector3 velocity = Vector3.zero; // camera damp v

    public float gate; // start of the first building after intro

    public PlayerRunning playerRunning;

    void FixedUpdate()
    {
        // define player position each frame
        playerPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        if (playerRunning.death != true) { // only follows when player isn't dead
            if (player.position.x < gate) { // start in-game follow after exiting first building
                target = new Vector3(10f, -4f, 0f);
            }
            else { // camera smooth follow
                target = new Vector3(10f, 0f, 0f);
            }
            transform.position = Vector3.SmoothDamp(transform.position, target + playerPosition, ref velocity, 0.15f);
        }
    }
}
