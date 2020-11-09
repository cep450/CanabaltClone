using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    // put under player's grounded check trigger, check grounding
    public PlayerJumping playerJumping; // assign to PlayerJumping script
    
    // grounded check
    void OnTriggerStay2D(Collider2D activator) {
        playerJumping.isGrounded = true;
    }
    void OnTriggerExit2D(Collider2D activator) {
        playerJumping.isGrounded = false;
    }
}
