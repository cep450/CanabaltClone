using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    // put under player's grounded check trigger, check grounding
    public PlayerJumping playerJumping; // assign to PlayerJumping script

    IEnumerator CayoteTime() {
        if (playerJumping.isJumping) {
            yield return 0;
            playerJumping.isGrounded = false;
        }
        else {
            yield return new WaitForSeconds(.2f);
            playerJumping.isGrounded = false;
        }
    }
    
    // grounded check
    void OnTriggerStay2D(Collider2D activator) {
        if (activator.tag == "Floor") {
            playerJumping.isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D activator) {
        if (activator.tag == "Floor") {
            if (!playerJumping.isJumping) {
                StartCoroutine(CayoteTime());
            }
            else {
                playerJumping.isGrounded = false;
            }
        }
    }
}
