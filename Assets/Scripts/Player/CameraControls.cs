using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform player; // player transform
    private Vector3 playerPosition; // current player position
    private Vector3 target; // camera target position
    private Vector3 velocity = Vector3.zero; // camera damp v

    public PlayerRunning playerRunning;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // define player position each frame
        playerPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        if (playerRunning.death != true) {
            if (player.position.y >= -5f) { // starting camera position
                target = new Vector3(10f, -4f, 0f);
                transform.position = playerPosition + target;
            }
            else { // camera smooth follow
                target = new Vector3(10f, 0f, 0f);
                transform.position = Vector3.SmoothDamp(transform.position, target + playerPosition, ref velocity, 0.15f);
            }
        }
    }
}
