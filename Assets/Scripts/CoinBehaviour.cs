using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Coins's 2D Movement and On player contact effects Behaviours after spawning (droped!):
public class CoinBehaviour : MonoBehaviour
{
    public uint coinValue = 1;

    // Movement amplifying rate:
    public float movingRate;

    // References:
    DropBehaviour dropAct;
    MoneyManager moneyManager;
    Rigidbody2D rgbd;
    Vector2 currentSpeed;

    // Control boolean:
    bool movingTowardPlayer;


    void Start() {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        dropAct = gameObject.GetComponent<DropBehaviour>();

        movingTowardPlayer = false;

        GameObject gameControllerObj = GameObject.FindWithTag("GameController");

        if (gameControllerObj) {
            moneyManager = gameControllerObj.GetComponent<MoneyManager>();
        } else {
            Debug.Log("Game Controller not found");
        }
    }

    void Update() {
        // Update the Movements and changes in Behaviours over time:
        movingTowardPlayer = dropAct.DoneBursting();
        // Burst > Still > Homing!
        if (movingTowardPlayer) {
            MoveTowardPlayer();
        }
    }

    // Player getting coins:
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerReceive(other);

            Destroy(gameObject);
        }
    }

    void MoveTowardPlayer() {
        // Player Obj Ref + Transform Component Ref:
        GameObject playerObj = GameObject.FindWithTag("Player");
        Transform playerTransform;


        if (playerObj) {
            playerTransform = playerObj.transform;
            transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * movingRate);
        }
    }

    void PlayerReceive(Collider2D player) {
        // Coin manager process:
        moneyManager.IncreaseCurrent((int)coinValue);

        // Play Special Visual + Audio Effects:
        PlayEffects();
    }

    void PlayEffects() {

    }
}
