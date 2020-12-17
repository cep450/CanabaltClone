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

    public bool shaking;
    public float shakeDuration;
    public float shakeMagnitude;

    void Start() {
        StartCoroutine(CameraShakeCoroutine());
    }

    public IEnumerator CameraShakeCoroutine() {
        if (playerRunning.death != true && shaking) {
            float shakeTime = 0f;

            while (shakeTime < shakeDuration) {
                float y = Random.Range(-1f, 1f) * shakeMagnitude;

                transform.position = new Vector3(playerPosition.x + 7f, playerPosition.y + y, transform.position.z);
                shakeTime += Time.deltaTime;

                yield return 0;
            }

            shaking = false;
        }
    }

    void FixedUpdate()
    {
        // define player position each frame
        playerPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        if (playerRunning.death != true && !shaking) { // only follows when player isn't dead
            target = new Vector3(7f, 0f, 0f);
            transform.position = Vector3.SmoothDamp(transform.position, target + playerPosition, ref velocity, 0.15f);
        }

    }
}
