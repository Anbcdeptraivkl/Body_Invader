using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Coins's 2D Movement and On player contact effects Behaviours after spawning (droped!):
public class CoinBehaviour : MonoBehaviour
{
    // The absolute for the random velocity at the beginning:
    public Vector2 burstSpeed;

    // Burst-out time:
    public float burstTime;

    // Standing still time:
    public float stillTime;

    // Movement amplifying rate:
    public float movingRate;

    public uint coinValue = 1;


    // References:
    MoneyManager moneyManager;

    // Holder Properties:
    Vector2 currentSetSpeed;

    Rigidbody2D rgbd;

    // Control boolean:
    bool movingTowardPlayer;


    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        movingTowardPlayer = false;

        GameObject gameControllerObj = GameObject.FindWithTag("GameController");

        if (gameControllerObj) {
            moneyManager = gameControllerObj.GetComponent<MoneyManager>();
        } else {
            Debug.Log("Game Controller not found");
        }

        StartCoroutine("StepByStepMove");
    }

    void Update() {
        // Update the Movements and changes in Behaviours over time:
        // Burst > Still > Homing!
        if (movingTowardPlayer) {
            MoveTowardPlayer();
        } else {
            rgbd.velocity = new Vector2(currentSetSpeed.x, currentSetSpeed.y);
        }
    }

    // Player getting coins:
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerReceive(other);

            Destroy(gameObject);
        }
    }

    IEnumerator StepByStepMove() {
        // The Coin bursts out:
        float burstX = Random.Range(-burstSpeed.x, burstSpeed.x);
        float burstY = Random.Range(-burstSpeed.y, burstSpeed.y);

        currentSetSpeed = new Vector2(burstX, burstY);
        yield return new WaitForSeconds(burstTime);

        // Stay still for a short amount of time:
        currentSetSpeed = Vector2.zero;
        yield return new WaitForSeconds(stillTime);

        // After that, start the state where the coins move toward the player (Move to Pick-up):
        movingTowardPlayer = true;
    }

    void MoveTowardPlayer() {
        // Player Obj Ref + Transform Component Ref:
        GameObject playerObj = GameObject.FindWithTag("Player");
        Transform playerTransform;


        if (playerObj) {

            playerTransform = playerObj.transform;
            transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * movingRate);
        }
        else {
            Debug.Log("Player not found or destroyed");
        }

    }

    void PlayerReceive(Collider2D player) {
        // Coin manager process:
        moneyManager.IncreaseCurrent((int)coinValue);

        // Play Special Visual + Audio Effects:
        PlayEffects();

        // Log:
        Debug.Log("Picked " + gameObject.name + "!");
    }

    void PlayEffects() {

    }

    
}
